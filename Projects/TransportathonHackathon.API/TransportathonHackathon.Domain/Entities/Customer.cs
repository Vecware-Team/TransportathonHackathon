using Core.Persistence.Entities;
using System.ComponentModel.DataAnnotations;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Customer : Entity
    {
        [Key]
        public Guid AppUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
