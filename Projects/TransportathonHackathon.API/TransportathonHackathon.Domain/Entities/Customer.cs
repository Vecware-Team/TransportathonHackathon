using Core.Persistence.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Customer : Entity
    {
        public Guid AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual AppUser AppUser { get; set; }
        public virtual ICollection<TransportRequest>? TransportRequests { get; set; }
    }
}
