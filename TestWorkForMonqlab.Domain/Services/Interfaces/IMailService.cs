using System.Collections.Generic;
using TestWorkForMonqlab.Domain.Data.Models;
using TestWorkForMonqlab.Domain.DTOs;

namespace TestWorkForMonqlab.Domain.Services.Interfaces
{
    public interface IMailService
    {
        /// <summary>
        /// Метод должен отправлять email с информацией из <paramref name="message"/>
        /// </summary>
        /// <param name="message"></param>
        void Send(SendMessageDto message);

        /// <summary>
        /// Метод должен возвращать набор email'ов
        /// </summary>
        /// <returns>набор email'ов</returns>
        IEnumerable<Mail> Get();
    }
}
