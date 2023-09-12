using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class TransportRequestRepository : EfRepositoryBase<TransportRequest, ProjectDbContext>, ITransportRequestRepository
    {
        public TransportRequestRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
