using Core.Persistence.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Customer : Entity
    {
        [ForeignKey("AppUser")]
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
