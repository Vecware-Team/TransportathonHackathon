using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class Driver : Entity
    {
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual DriverLicense? DriverLicense { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
