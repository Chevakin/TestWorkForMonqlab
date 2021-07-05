using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TestWorkForMonqlab.Domain.Data.Models
{
    public class SmtpConfiguration
    {
        /// <summary>
        /// адрес отправителя SMTP сервера
        /// </summary>
        public string Host { get; private set; }

        /// <summary>
        /// Имя, которое будут видеть получатели
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// Порт, который будет использоваться для отправки
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Информация для авторизации на SMTP сервере
        /// </summary>
        public NetworkCredential Credential { get; private set; }

        /// <summary>
        /// Нужно ли включать SSL
        /// </summary>
        public bool EnableSsl { get; private set; }

        public SmtpConfiguration(string host, string displayName, int port, NetworkCredential credential, bool enableSsl)
        {
            if (string.IsNullOrEmpty(host) && new EmailAddressAttribute().IsValid(host) == false)
            {
                throw new ArgumentException($"{nameof(host)} не является валидным адресом.");
            }

            if (string.IsNullOrEmpty(displayName))
            {
                throw new ArgumentException($"\"{nameof(displayName)}\" не может быть неопределенным или пустым.", nameof(displayName));
            }

            if (credential is null)
            {
                throw new ArgumentNullException(nameof(credential));
            }

            Host = host;
            DisplayName = displayName;
            Port = port;
            Credential = credential;
            EnableSsl = enableSsl;
        }
    }
}
