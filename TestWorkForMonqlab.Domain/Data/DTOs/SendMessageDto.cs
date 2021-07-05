using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestWorkForMonqlab.Domain.DTOs
{
    public class SendMessageDto
    {
        /// <summary>
        /// Тема сообщения
        /// </summary>
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        [JsonPropertyName("body")]
        public string Body { get; set; }

        /// <summary>
        /// Список email'ов получателей сообщения
        /// </summary>
        [JsonPropertyName("recipients")]
        public IEnumerable<string> Recipients { get; set; }
    }
}
