namespace TransportathonHackathon.Application.Features.Trucks.Commands.Create
{
    public class CreatedTruckResponse
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
