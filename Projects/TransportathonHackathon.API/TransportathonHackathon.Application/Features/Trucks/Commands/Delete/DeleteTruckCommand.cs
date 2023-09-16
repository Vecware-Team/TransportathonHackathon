using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Delete
{
    public class DeleteTruckCommand : IRequest<DeletedTruckResponse>, ITransactionalRequest
    {
        public Guid VehicleId { get; set; }
    }
}
