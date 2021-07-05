using System;
using System.Collections.Generic;

namespace TestWorkForMonqlab.Domain.Data.Models
{
    public class Mail
    {
        /// <summary>
        /// ID сообщения <c> > 0</c>
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Тема сообщения
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Дата создания сообщения
        /// </summary>
        public DateTime Create { get; set; }

        /// <summary>
        /// Результат попытки отправить сообщение
        /// </summary>
        public MailResult Result { get; set; }

        /// <summary>
        /// Сообщение об ошибке отпаравки сообщения
        /// <remark><c>null</c> если отправка успешна</remark>
        /// </summary>
        public string FailedMessage { get; set; }

        /// <summary>
        /// Список email'ов получателей сообщения
        /// </summary>
        public HashSet<string> Recipients { get; set; }

        public Mail()
        {
            Create = DateTime.Now;

            Recipients = new HashSet<string>();
        }
    }
}
