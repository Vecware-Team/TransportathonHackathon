using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Delete
{
    public class DeletePickupTruckCommand : IRequest<DeletedPickupTruckResponse>, ITransactionalRequest
    {
        public Guid VehicleId { get; set; }
    }
}
