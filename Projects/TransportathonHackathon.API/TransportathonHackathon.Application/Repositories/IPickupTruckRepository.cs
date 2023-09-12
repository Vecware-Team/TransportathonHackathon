using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface IPickupTruckRepository : IAsyncRepository<PickupTruck>, IRepository<PickupTruck>
    {
    }
}
