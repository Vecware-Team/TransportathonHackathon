using Core.Persistence.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Driver : Entity
    {
        public Guid EmployeeId { get; set; }

        public virtual DriverLicense? DriverLicense { get; set; }
        public virtual AppUser AppUser { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
