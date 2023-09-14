using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface IMessageRepository : IAsyncRepository<Message>, IRepository<Message>
    {
    }
}
