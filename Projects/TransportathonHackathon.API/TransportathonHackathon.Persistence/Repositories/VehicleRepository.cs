using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class VehicleRepository : EfRepositoryBase<Vehicle, ProjectDbContext>, IVehicleRepository
    {
        public VehicleRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
