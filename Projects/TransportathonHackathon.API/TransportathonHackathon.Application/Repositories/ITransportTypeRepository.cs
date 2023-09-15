using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ITransportTypeRepository : IAsyncRepository<TransportType>, IRepository<TransportType>
    {
    }
}
