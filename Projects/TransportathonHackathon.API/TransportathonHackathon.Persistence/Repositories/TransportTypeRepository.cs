using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class TransportTypeRepository : EfRepositoryBase<TransportType, ProjectDbContext>, ITransportTypeRepository
    {
        public TransportTypeRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
