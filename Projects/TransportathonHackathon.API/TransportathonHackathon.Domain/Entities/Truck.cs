using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class Truck : Entity
    {
        public Guid VehicleId { get; set; }
        
        public int Size { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
