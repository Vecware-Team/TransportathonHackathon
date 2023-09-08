using Core.Persistence.Entities;
using System.ComponentModel.DataAnnotations;
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
    }
}
