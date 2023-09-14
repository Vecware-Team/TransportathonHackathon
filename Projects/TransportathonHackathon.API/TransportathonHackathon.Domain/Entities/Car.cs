using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class Car : Entity
    {
        public Guid VehicleId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
