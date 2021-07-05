using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TestWorkForMonqlab.Domain.DTOs
{
    public class SendMessageDto
    {
        [JsonPropertyName("subject")]
        public string Subject { get; set; }

        [JsonPropertyName("body")]
        public string Body { get; set; }

        [JsonPropertyName("recipients")]
        public IEnumerable<string> Recipients { get; set; }
    }
}
