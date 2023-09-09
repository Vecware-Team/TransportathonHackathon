using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class CarrierRepository : EfRepositoryBase<Carrier, ProjectDbContext>, ICarrierRepository
    {
        public CarrierRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
