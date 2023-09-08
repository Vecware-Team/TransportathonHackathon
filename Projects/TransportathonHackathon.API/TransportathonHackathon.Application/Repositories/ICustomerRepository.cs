using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface ICustomerRepository: IRepository<Customer>, IAsyncRepository<Customer>
    {
    }
}
