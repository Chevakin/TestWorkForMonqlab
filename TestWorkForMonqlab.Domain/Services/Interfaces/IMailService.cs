using System.Collections.Generic;
using TestWorkForMonqlab.Domain.Data.Models;
using TestWorkForMonqlab.Domain.DTOs;

namespace TestWorkForMonqlab.Domain.Services.Interfaces
{
    public interface IMailService
    {
        void Send(SendMessageDto message);

        IEnumerable<Mail> Get();
    }
}
