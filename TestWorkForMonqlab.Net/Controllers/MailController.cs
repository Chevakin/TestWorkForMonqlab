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

        /// <summary>
        /// Метод контроллера, который отправляет email с информацией из <paramref name="message"/>
        /// </summary>
        /// <param name="message">Получается из тела запроса
        /// <example>
        /// {
        ///     "subject": "string",
        ///     "body": "string",
        ///     "recipients": [ "pandromeda@bk.ru" ]
        /// }
        /// </example></param>
        [Route("")]
        [HttpPost]
        public void Send([FromBody] SendMessageDto message)
        {
            _service.Send(message);
        }

        /// <summary>
        /// Метод контроллера, который возвращает массив email'ов в формате json
        /// </summary>
        /// <returns>массив email'ов в формате json
        /// <example>
        /// [
        ///     {
        ///         "id": 1,
        ///         "subject": "string",
        ///         "body": "string",
        ///         "create": "2021-07-05T21:07:32.3475118",
        ///         "result": 1,
        ///         "failedMessage": null,
        ///         "recipients": []
        ///     }
        /// ]
        /// </example></returns>
        [Route("")]
        [HttpGet]
        public JsonResult Get()
        {
            return Json(_service.Get());
        }
    }
}
