using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface IEmployeeRepository : IAsyncRepository<Employee>, IRepository<Employee>
    {
    }
}
