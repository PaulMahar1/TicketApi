using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TicketApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {

        private readonly ILogger<TicketController> _logger;
        private readonly IConfiguration _configuration;

        public TicketController(ILogger<TicketController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }


        // GET api/<TicketController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Hey";
        }

        [HttpPost]
        public async Task<IActionResult> Post(Contact contact)
        {

            if (ModelState.IsValid == false)
            {
                BadRequest(ModelState);
            }

            string queueName = "tickets";
            string connectionString = "DefaultEndpointsProtocol=https;AccountName=nscc0179231storageacct;AccountKey=x4h6WI7XR4SFBPht5GsZI/+FoBtP9Urwj8r9me6NZyTMpt7j4cuAS/Yviyy5DDaFl37q7WSI2uHF+AStV40qEQ==;EndpointSuffix=core.windows.net";
            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(contact);

            // send string message to queue
            await queueClient.SendMessageAsync(message);

            return Ok(contact);
        }


    }
}

