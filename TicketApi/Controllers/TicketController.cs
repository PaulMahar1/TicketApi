﻿using Azure.Storage.Queues;
using System.Runtime.InteropServices.Marshalling;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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
        [HttpGet]
        public string Get()
        {
            return "Hey";
        }

        [HttpPost]
        public async Task<IActionResult> Post(Ticket ticket)
        {

            if (ModelState.IsValid == false)
            {
                BadRequest(ModelState);
            }
            //Code change
            string queueName = "tickets";

            string? connectionString = _configuration["AzureStorageConnectionString"];

            if (string.IsNullOrEmpty(connectionString))
            {
                return BadRequest("An error was encountered");
            }

            QueueClient queueClient = new QueueClient(connectionString, queueName);

            // serialize an object to json
            string message = JsonSerializer.Serialize(ticket);

            // serialize an object to json
            var plainBytes = Encoding.UTF8.GetBytes(message);
            string base64Message = Convert.ToBase64String(plainBytes);
            // send string message to queue
            await queueClient.SendMessageAsync(base64Message);


            return Ok(message);
        }


    }
}

