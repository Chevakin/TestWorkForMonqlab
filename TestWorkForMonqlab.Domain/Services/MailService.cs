using System.ComponentModel.DataAnnotations;
using System.Linq;
using TestWorkForMonqlab.Domain.Data.DB;
using TestWorkForMonqlab.Domain.Data.Models;
using TestWorkForMonqlab.Domain.DTOs;
using TestWorkForMonqlab.Domain.Services.Interfaces;

namespace TestWorkForMonqlab.Domain.Services
{
    public class MailService : IMailService
    {
        private readonly MonqlabDbContext _context;

        public MailService(MonqlabDbContext context)
        {
            _context = context;
        }

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


        }
    }
}
