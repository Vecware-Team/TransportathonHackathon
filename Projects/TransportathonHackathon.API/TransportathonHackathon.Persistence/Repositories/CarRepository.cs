using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class CarRepository : EfRepositoryBase<Car, ProjectDbContext>, ICarRepository
    {
        public CarRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
