using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface IVehicleRepository : IAsyncRepository<Vehicle>, IRepository<Vehicle>
    {
    }
}
