using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommand : IRequest<DeletedCarResponse>, ITransactionalRequest
    {
        public Guid VehicleId { get; set; }
    }
}
