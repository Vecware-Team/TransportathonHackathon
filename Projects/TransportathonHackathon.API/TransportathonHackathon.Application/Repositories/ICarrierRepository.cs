using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ICarrierRepository : IAsyncRepository<Carrier>, IRepository<Carrier>
    {
    }
}
