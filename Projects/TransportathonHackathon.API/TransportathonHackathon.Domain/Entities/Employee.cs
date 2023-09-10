using Core.Persistence.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Employee : Entity
    {
        public Guid AppUserId { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsOnTransitNow { get; set; }

        public virtual Carrier? Carrier { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual Company Company { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
