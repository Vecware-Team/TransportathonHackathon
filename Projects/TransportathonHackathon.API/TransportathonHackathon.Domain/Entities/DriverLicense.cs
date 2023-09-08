using Core.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportathonHackathon.Domain.Entities
{
    public class DriverLicense : Entity<Guid>
    {
        public DateTime LicenseGetDate { get; set; }
        public Guid DriverId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Classes { get; set; }
        public bool IsNew { get; set; }

        public virtual Driver Driver { get; set; }
    }
}
