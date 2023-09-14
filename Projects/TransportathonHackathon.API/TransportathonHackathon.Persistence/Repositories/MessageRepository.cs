using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class MessageRepository : EfRepositoryBase<Message, ProjectDbContext>, IMessageRepository
    {
        public MessageRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
