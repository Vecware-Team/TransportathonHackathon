using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class PickupTruckRepository : EfRepositoryBase<PickupTruck, ProjectDbContext>, IPickupTruckRepository
    {
        public PickupTruckRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
