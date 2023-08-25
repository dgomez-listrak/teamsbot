using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Builder;

namespace AdaptiveCardsBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebHookController : ControllerBase
    {

        private readonly IBotFrameworkHttpAdapter _adapter;
        private readonly IBot _bot;

        public WebHookController(IBotFrameworkHttpAdapter adapter, IBot bot)
        {
            _adapter = adapter;
            _bot = bot;
        }


        // POST api/webhooks/receive
        [HttpPost("receive")]
        public async Task<IActionResult> ReceiveWebhook([FromBody] string data)
        {
            if (data == null)
            {
                return BadRequest();
            }
            await _adapter.ProcessAsync(Request, Response, _bot);
            // Process the received data
            // For instance, log the data, store it in a database, etc.

            // Once done, return a suitable response. Typically, for webhooks, you'd return a 200 OK.
            return Ok();
        }

    }
}
