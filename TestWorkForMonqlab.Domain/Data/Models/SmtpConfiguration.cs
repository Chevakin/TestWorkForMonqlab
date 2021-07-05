using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace TestWorkForMonqlab.Domain.Data.Models
{
    public class SmtpConfiguration
    {
        public string Host { get; private set; }

        public string DisplayName { get; private set; }

        public int Port { get; private set; }

        public NetworkCredential Credential { get; private set; }

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
