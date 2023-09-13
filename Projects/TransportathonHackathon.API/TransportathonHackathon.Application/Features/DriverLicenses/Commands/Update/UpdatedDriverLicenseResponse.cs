using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Update
{
    public class UpdatedDriverLicenseResponse
    {
        public Guid DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }
        public DateTime LicenseGetDate { get; set; }

        public Driver Driver { get; set; }
    }
}
