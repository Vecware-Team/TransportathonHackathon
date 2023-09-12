using MediatR;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Update
{
    public class UpdateTruckCommand : IRequest<UpdatedTruckResponse>
    {
        public Guid VehicleId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
        public int Size { get; set; }
    }
}
