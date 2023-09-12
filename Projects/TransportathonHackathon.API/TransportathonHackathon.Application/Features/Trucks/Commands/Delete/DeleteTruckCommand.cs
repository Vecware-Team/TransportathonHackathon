using MediatR;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Delete
{
    public class DeleteTruckCommand : IRequest<DeletedTruckResponse>
    {
        public Guid VehicleId { get; set; }
    }
}
