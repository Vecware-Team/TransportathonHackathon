using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Services
{
    public interface IMessageService
    {
        Task<Message?> GetById(Guid id);
        Task<Message?> GetLastMessage();
        Task SaveMessage(Message message);
        Task MarkAsRead(Message message);
    }
}
