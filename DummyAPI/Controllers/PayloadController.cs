using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using DummyAPI.Utilitites;

namespace DummyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayloadController : ControllerBase
    {
        [HttpPost]
        public IActionResult ReceivePayload([FromBody] JsonElement payload)
        {
            if (payload.ValueKind == JsonValueKind.Undefined)
            {
                return BadRequest("Payload is required");
            }

            string payloadString = JsonSerializer.Serialize(payload);
            // Logs are on the QA MQ 01 server on the D drive. 
            LogWriter.Log($"JSONPayload: {payloadString}");

            return Ok(new 
            { 
                Message = "Payload received successfully",
                PayloadString = payloadString
            });
        }
    }
}
