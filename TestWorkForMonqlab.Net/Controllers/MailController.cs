using Microsoft.AspNetCore.Mvc;
using TestWorkForMonqlab.Domain.DTOs;
using TestWorkForMonqlab.Domain.Services.Interfaces;

namespace TestWorkForMonqlab.Net.Controllers
{
    [Route("api/mails")]
    public class MailController : Controller
    {
        private readonly IMailService _service;

        public MailController(IMailService service)
        {
            _service = service;
        }

        [Route("")]
        [HttpPost]
        public void Send([FromBody]SendMessageDto message)
        {
            _service.Send(message);
        }

        [Route("")]
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_service.Get());
        }
    }
}
