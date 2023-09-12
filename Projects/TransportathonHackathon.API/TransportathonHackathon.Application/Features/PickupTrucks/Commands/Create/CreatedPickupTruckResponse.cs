namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Create
{
    public class CreatedPickupTruckResponse
    {
        public Guid VehicleId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int Size { get; set; }
        public string CompanyName { get; set; }
        public string DriverName { get; set; }
    }
}
