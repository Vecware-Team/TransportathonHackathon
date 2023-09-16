namespace TransportathonHackathon.WebAPI.Dtos.Truck
{
    public class CreateTruckDto
    {
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int Size { get; set; }
    }
}
