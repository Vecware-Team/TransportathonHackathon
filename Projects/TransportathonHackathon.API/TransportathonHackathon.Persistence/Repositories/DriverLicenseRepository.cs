using Core.Persistence.Repositories;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;
using TransportathonHackathon.Persistence.Contexts;

namespace TransportathonHackathon.Persistence.Repositories
{
    public class DriverLicenseRepository : EfRepositoryBase<DriverLicense, ProjectDbContext>, IDriverLicenseRepository
    {
        public DriverLicenseRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
