using Core.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
