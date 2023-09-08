using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class DriverRepository : EfRepositoryBase<Driver, ProjectDbContext>, IDriverRepository
    {
        public DriverRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
