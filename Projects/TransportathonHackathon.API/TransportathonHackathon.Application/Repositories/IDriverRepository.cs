using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface IDriverRepository: IRepository<Driver>, IAsyncRepository<Driver>
    {
    }
}
