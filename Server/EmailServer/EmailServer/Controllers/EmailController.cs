using System.Collections.Generic;
using System.Threading.Tasks;
using EmailServer.Components;
using EmailServer.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailServer.Controllers
{
    [Route("api/[controller]")]
    public class EmailController : Controller
    {
        private readonly EmailComponent _emailComponent;

        public EmailController(EmailComponent emailComponent)
        {
            _emailComponent = emailComponent;
        }

        [HttpGet]
        [Route("GetReceived")]
        public async Task<IEnumerable<EmailModel>> GetReceived()
        {
            var emails = await _emailComponent.GetReceived();

            return emails;
        }

        [HttpGet]
        [Route("GetSent")]
        public async Task<IEnumerable<EmailModel>> GetSent()
        {
            var emails = await _emailComponent.GetSent();

            return emails;
        }

        [HttpGet("{id}")]
        public async Task<EmailModel> Get(int id)
        {
            var email = await _emailComponent.Get(id);

            return email;
        }

        [HttpPost]
        [Route("Send")]
        public async Task<IActionResult> Send([FromBody]EmailModel emailModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _emailComponent.Send(emailModel);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _emailComponent.Delete(id);

            return new NoContentResult();
        }
    }
}
