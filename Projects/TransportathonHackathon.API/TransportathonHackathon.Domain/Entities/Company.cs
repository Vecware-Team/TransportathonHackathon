using Core.Persistence.Entities;
using System.ComponentModel.DataAnnotations;
using TransportathonHackathon.Domain.Entities.Identity;

namespace TransportathonHackathon.Domain.Entities
{
    public class Company : Entity
    {
        [Key]
        public Guid AppUserId { get; set; }
        public string CompanyName { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}
