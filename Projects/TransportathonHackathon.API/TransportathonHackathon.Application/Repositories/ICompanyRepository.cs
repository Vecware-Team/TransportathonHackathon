using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ICompanyRepository : IRepository<Company>, IAsyncRepository<Company>
    {
    }
}
