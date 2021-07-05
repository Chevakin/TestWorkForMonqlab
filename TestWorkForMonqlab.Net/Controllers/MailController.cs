using Microsoft.AspNetCore.Mvc;
using TestWorkForMonqlab.Domain.DTOs;
using TestWorkForMonqlab.Domain.Services;

namespace TestWorkForMonqlab.Net.Controllers
{
    [Route("api/mails")]
    public class MailController : Controller
    {
        private readonly MailService _service;

        public MailController(MailService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpPost]
        public void Send([FromBody]SendMessageDto message)
        {
            _service.Send(message);
        }
    }
}
