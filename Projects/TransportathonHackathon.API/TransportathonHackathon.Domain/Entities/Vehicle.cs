using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class Vehicle : Entity<Guid>
    {
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }

        public virtual Company Company { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual Car? Car { get; set; }
        public virtual Truck? Truck { get; set; }
        public virtual PickupTruck? PickupTruck { get; set; }
        public virtual TransportRequest? TransportRequest { get; set; }
    }
}
