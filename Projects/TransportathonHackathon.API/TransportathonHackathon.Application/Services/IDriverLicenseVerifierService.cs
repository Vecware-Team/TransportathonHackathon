using TransportathonHackathon.Application.Requests;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Services
{
    public interface IDriverLicenseVerifierService
    {
        Task<bool> Verify(DriverLicenseRequest driverLicenseRequest);
    }
}
