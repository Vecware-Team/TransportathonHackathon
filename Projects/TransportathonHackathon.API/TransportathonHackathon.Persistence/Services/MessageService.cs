using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Application.Services;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Persistence.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<Message?> GetById(Guid id)
        {
            return await _messageRepository.GetAsync(e => e.Id == id, include: e => e.Include(e => e.Sender).Include(e => e.Receiver));
        }

        public async Task<Message?> GetLastMessage()
        {
            IList<Message> messages = await _messageRepository.GetListAsync(orderBy: e => e.OrderBy(e => e.Queue));
            if (messages.Count == 0) return null;

            return messages.Last();
        }

        public async Task SaveMessage(Message message)
        {
            await _messageRepository.AddAsync(message);
        }

        public async Task MarkAsRead(Message message)
        {
            message.IsRead = true;
            await _messageRepository.UpdateAsync(message);
        }

    }
}
