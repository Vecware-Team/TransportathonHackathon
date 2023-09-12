using MediatR;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Delete
{
    public class DeletePickupTruckCommand : IRequest<DeletedPickupTruckResponse>
    {
        public Guid VehicleId { get; set; }
    }
}
