using TestWorkForMonqlab.Domain.DTOs;

namespace TestWorkForMonqlab.Domain.Services.Interfaces
{
    public interface IMailService
    {
        void Send(SendMessageDto message);
    }
}
