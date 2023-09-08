using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class CompanyRepository : EfRepositoryBase<Company, ProjectDbContext>, ICompanyRepository
    {
        public CompanyRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
