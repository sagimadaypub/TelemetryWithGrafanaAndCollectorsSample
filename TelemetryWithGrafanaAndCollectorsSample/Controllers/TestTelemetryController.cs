using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace TelemetryWithGrafanaAndCollectorsSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestTelemetryController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Telemetry as been collected");
        }
    }
}
