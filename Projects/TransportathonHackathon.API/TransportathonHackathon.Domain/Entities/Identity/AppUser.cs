using Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace TransportathonHackathon.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>, IEntity<Guid>
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

        public virtual Company Company { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
