using System;
using System.Collections.Generic;

namespace TestWorkForMonqlab.Domain.Data.Models
{
    public class Mail
    {
        public Mail()
        {
            Create = DateTime.Now;

            Recipients = new HashSet<string>();
        }

        public int ID { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public HashSet<string> Recipients { get; set; }

        public DateTime Create { get; set; }

        public MailResult Result { get; set; }
    }
}
