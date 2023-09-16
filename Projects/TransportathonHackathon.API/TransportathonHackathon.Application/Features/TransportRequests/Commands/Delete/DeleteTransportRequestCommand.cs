using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete
{
    public class DeleteTransportRequestCommand : IRequest<DeletedTransportRequestResponse>, ITransactionalRequest
    {
        public Guid Id { get; set; }
    }
}
