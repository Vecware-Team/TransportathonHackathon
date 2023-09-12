using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ITruckRepository : IAsyncRepository<Truck>, IRepository<Truck>
    {
    }
}
