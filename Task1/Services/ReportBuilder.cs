using System.Text;
using Task1.Services.Interfaces;

namespace Task1.Services
{
    public class ReportBuilder : IReportBuilder
    {
        private readonly Random _random = new Random();

        public byte[] Build(CancellationToken cancellationToken)
        {
            int buildTime = _random.Next(5, 46);
            bool willFail = _random.Next(0, 5) == 0;

            for (int i = 0; i < buildTime; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();
                Thread.Sleep(1000);

                if (willFail && i == 2)
                {
                    throw new Exception("Report failed");
                }
            }

            string reportText = $"Report built in {buildTime} s.";
            return Encoding.UTF8.GetBytes(reportText);
        }
    }

}
