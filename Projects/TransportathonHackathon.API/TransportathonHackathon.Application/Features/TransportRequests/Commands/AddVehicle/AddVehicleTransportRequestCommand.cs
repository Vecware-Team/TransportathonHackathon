using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.AddVehicle
{
    public class AddVehicleTransportRequestCommand : IRequest<AddVehicleTransportRequestResponse>
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
    }
}
