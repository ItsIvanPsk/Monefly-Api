using System.ComponentModel;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MonefyWeb.Transversal.Aspects;
using Swashbuckle.AspNetCore.Annotations;

namespace MonefyWeb.DistributedServices.WebApi.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;
        private readonly HealthCheckService _service;

        public HealthCheckController(
            ILogger<HealthCheckController> logger,
            HealthCheckService service
        )
        {
            _logger = logger;
            _service = service;
        }

        [Log]
        [Timer]
        [HttpGet]
        public async Task<IActionResult> Get(
            [SwaggerParameter("2")][DefaultValue(2)][FromRoute] string version
        )
        {
            try
            {
                var report = await _service.CheckHealthAsync();
                string json = JsonSerializer.Serialize(report, new JsonSerializerOptions
                {
                    WriteIndented = true
                });

                if (report.Status == HealthStatus.Healthy)
                    return Ok(json);

                return NotFound("Service unavailable");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en la acción Get de HealthCheckController");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
