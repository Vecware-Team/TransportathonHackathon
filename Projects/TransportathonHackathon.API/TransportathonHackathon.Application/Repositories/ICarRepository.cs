using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ICarRepository : IAsyncRepository<Car>, IRepository<Car>
    {
    }
}
