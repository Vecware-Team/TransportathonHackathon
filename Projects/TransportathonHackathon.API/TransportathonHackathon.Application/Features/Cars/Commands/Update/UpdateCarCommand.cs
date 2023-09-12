using MediatR;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Update
{
    public class UpdateCarCommand : IRequest<UpdatedCarResponse>
    {
        public Guid VehicleId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid DriverId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ModelYear { get; set; }
    }
}
