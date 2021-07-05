using Microsoft.Extensions.Configuration;
using System.Net;
using TestWorkForMonqlab.Domain.Data.Models;

namespace TestWorkForMonqlab.Domain.Extensions
{
    public static class ConfigurationExtensions
    {
        private const string _smtpConfigurationSectionName = "SMTPConfiguration";

        /// <summary>
        /// Этот метод расширяет <c>IConfiguration</c> должен получать из конфигурационного файла секцию
        /// с конфигурацией для SMTP сервера и маппить ее к <c>SmtpConfiguration</c>
        /// </summary>
        /// <param name="configuration"></param>
        /// <returns>конфигурацию SMTP сервера из конфигурационного файла</returns>
        public static SmtpConfiguration GetSmtpConfiguration(this IConfiguration configuration)
        {
            var section = configuration.GetSection(_smtpConfigurationSectionName);

            var host = section["Host"];
            var displayName = section["DisplayName"];
            var port = int.Parse(section["Port"]);
            var userName = section["UserName"];
            var password = section["Password"];
            var enableSsl = bool.Parse(section["EnableSsl"]);

            return new SmtpConfiguration(host, displayName, port, new NetworkCredential(userName, password), enableSsl);
        }
    }
}
