namespace TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetList
{
    public class GetListPickupTruckResponse
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
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
