using Core.Persistence.Entities;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Carrier : Entity
    {
        public Guid AppUserId { get; set; }
        public bool IsOnTransitNow { get; set; }

        public AppUser AppUser { get; set; }
    }
}
