using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class TruckRepository : EfRepositoryBase<Truck, ProjectDbContext>, ITruckRepository
    {
        public TruckRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
