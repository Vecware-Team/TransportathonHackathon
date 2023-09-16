using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Vehicles.Queries.GetByCompanyIdVehicle
{
    public class GetByCompanyIdVehicleResponse
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public virtual Driver? Driver { get; set; }
        public virtual Car? Car { get; set; }
        public virtual Truck? Truck { get; set; }
        public virtual PickupTruck? PickupTruck { get; set; }
    }
}
