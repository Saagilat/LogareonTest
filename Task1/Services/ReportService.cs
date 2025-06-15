using System.Collections.Concurrent;
using Task1.Services.Interfaces;

namespace Task1.Services
{
    public class ReportService
    {
        private readonly IReportBuilder _reportBuilder;
        private readonly IReporter _reporter;
        private readonly ConcurrentDictionary<int, CancellationTokenSource> _activeReports;
        private int _nextId = 0;
        private const int TimeoutSeconds = 30;

        public ReportService(IReportBuilder reportBuilder, IReporter reporter)
        {
            _reportBuilder = reportBuilder;
            _reporter = reporter;
            _activeReports = new ConcurrentDictionary<int, CancellationTokenSource>();
        }

        public int StartBuildingReport()
        {
            var id = Interlocked.Increment(ref _nextId) - 1;
            var cts = new CancellationTokenSource();

            _activeReports.TryAdd(id, cts);

            Task.Run(async () =>
            {
                try
                {
                    var timeoutTask = Task.Delay(TimeoutSeconds * 1000);
                    var buildTask = Task.Run(() => _reportBuilder.Build(cts.Token));

                    var completedTask = await Task.WhenAny(buildTask, timeoutTask);

                    if (completedTask == timeoutTask)
                    {
                        cts.Cancel();
                        _reporter.ReportTimeout(id);
                    }
                    else if (buildTask.IsFaulted)
                    {
                        _reporter.ReportError(id);
                    }
                    else
                    {
                        _reporter.ReportSuccess(buildTask.Result, id);
                    }
                }
                finally
                {
                    _activeReports.TryRemove(id, out _);
                }
            });

            return id;
        }

        public bool StopBuildingReport(int id)
        {
            if (_activeReports.TryGetValue(id, out var cts))
            {
                cts.Cancel();
                _activeReports.TryRemove(id, out _);
                return true;
            }
            return false;
        }
    }
}
