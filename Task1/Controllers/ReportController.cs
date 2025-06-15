using Microsoft.AspNetCore.Mvc;
using Task1.Services;

namespace Task1.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly ReportService _reportService;

        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("build")]
        public IActionResult Build()
        {
            var reportId = _reportService.StartBuildingReport();
            return Ok(reportId);
        }

        [HttpPost("stop")]
        public IActionResult Stop([FromBody] int reportId)
        {
            bool stopped = _reportService.StopBuildingReport(reportId);
            return stopped ? Ok() : NotFound();
        }
    }
}
