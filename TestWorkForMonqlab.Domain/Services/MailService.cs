using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mail;
using TestWorkForMonqlab.Domain.Data.DB;
using TestWorkForMonqlab.Domain.Data.Models;
using TestWorkForMonqlab.Domain.DTOs;
using TestWorkForMonqlab.Domain.Extensions;
using TestWorkForMonqlab.Domain.Services.Interfaces;

namespace TestWorkForMonqlab.Domain.Services
{
    public class MailService : IMailService
    {
        private readonly MonqlabDbContext _context;
        private readonly IConfiguration _configuration;

        public MailService(MonqlabDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /// <summary>
        /// Метод, который возвращает список email'ов из БД
        /// </summary>
        /// <returns>Список email'ов</returns>
        public IEnumerable<Mail> Get()
        {
            return _context.Mails.ToArray();
        }

        /// <summary>
        /// Метод, который пытается отправить письмо с информацией из <paramref name="message"/> и добавляет в его в БД 
        /// </summary>
        /// <param name="message"></param>
        public void Send(SendMessageDto message)
        {
            bool correct = false;

            //Я думаю что из-за одного класса не стоит использовать automapper
            //Я использовал его на https://github.com/Chevakin/TestJobForUralsib
            var mail = new Mail
            {
                Subject = message.Subject,
                Body = message.Body,
            };

            if (message.Recipients != null && message.Recipients.Count() > 0)
            {
                foreach (var r in message.Recipients)
                {
                    if (string.IsNullOrEmpty(r) == false && new EmailAddressAttribute().IsValid(r))
                    {
                        mail.Recipients.Add(r);
                    }
                }

                correct = mail.Recipients.Count() > 0;
            }

            if (correct)
            {
                try
                {
                    var smtpConfiguration = _configuration.GetSmtpConfiguration();
                    var mailMessage = GetMailMessage(mail, smtpConfiguration);
                    var smtpClient = new SmtpClient()
                    {
                        Host = smtpConfiguration.Host,
                        Port = smtpConfiguration.Port,
                        Credentials = smtpConfiguration.Credential,
                        EnableSsl = smtpConfiguration.EnableSsl
                    };


                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    correct = false;

                    mail.FailedMessage = ex.Message;
                }
            }
            else
            {
                mail.FailedMessage = "Нет корректных реципиентов";
            }

            mail.Result = correct ? MailResult.Ok : MailResult.Failed;

            _context.Mails.Add(mail);

            _context.SaveChanges();
        }

        private MailMessage GetMailMessage(Mail mail, SmtpConfiguration smtpConfiguration)
        {
            MailMessage m = new MailMessage
            {
                From = new MailAddress(smtpConfiguration.Host, smtpConfiguration.DisplayName),
                Subject = mail.Subject,
                Body = mail.Body
            };

            foreach (var r in mail.Recipients)
            {
                m.To.Add(r);
            }

            return m;
        }
    }
}
