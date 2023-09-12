using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ITransportRequestRepository : IAsyncRepository<TransportRequest>, IRepository<TransportRequest>
    {
    }
}
