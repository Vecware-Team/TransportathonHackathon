using Core.Persistence.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Repositories
{
    public interface IDriverLicenseRepository: IRepository<DriverLicense>, IAsyncRepository<DriverLicense>
    {
    }
}
