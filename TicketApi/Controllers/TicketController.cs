using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _configuration;

        public TicketController(ILogger<WeatherForecastController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello from Ticket Controller - GET()");
        }

        [HttpPost]
        public IActionResult Post(Contact contact)
        {

            if (ModelState.IsValid == false)
            {
                BadRequest(ModelState);
            }
            return Ok("Hello from the Ticket Controller - POST()");
        }
    }
}
