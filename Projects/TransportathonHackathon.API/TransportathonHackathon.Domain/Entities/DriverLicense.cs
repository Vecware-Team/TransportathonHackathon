using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class DriverLicense : Entity
    {
        public Guid DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }
        public DateTime LicenseGetDate { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
