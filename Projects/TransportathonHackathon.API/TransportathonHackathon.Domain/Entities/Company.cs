using Core.Persistence.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Company : Entity
    {
        public Guid AppUserId { get; set; }
        public string CompanyName { get; set; }
        public int DriverCount { get; set; }
        public int CompletedJobsCount { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
        public virtual ICollection<TransportRequest>? TransportRequests { get; set; }
        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
