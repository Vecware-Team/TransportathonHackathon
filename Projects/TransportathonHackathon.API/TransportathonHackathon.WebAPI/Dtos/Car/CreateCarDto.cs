namespace TransportathonHackathon.WebAPI.Dtos.Car
{
    public class CreateCarDto
    {
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
    }
}
