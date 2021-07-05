using Microsoft.Extensions.Configuration;
using System.Net;
using TestWorkForMonqlab.Domain.Data.Models;

namespace TestWorkForMonqlab.Domain.Extensions
{
    public static class ConfigurationExtensions
    {
        public static SmtpConfiguration GetSmtpConfiguration(this IConfiguration configuration)
        {
            var section = configuration.GetSection("SMTPConfiguration");

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
