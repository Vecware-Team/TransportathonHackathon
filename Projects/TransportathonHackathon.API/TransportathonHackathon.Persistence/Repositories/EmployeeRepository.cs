using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class EmployeeRepository : EfRepositoryBase<Employee, ProjectDbContext>, IEmployeeRepository
    {
        public EmployeeRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
