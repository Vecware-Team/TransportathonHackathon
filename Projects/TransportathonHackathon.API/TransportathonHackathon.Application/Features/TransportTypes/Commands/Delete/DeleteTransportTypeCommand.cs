using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete
{
    public class DeleteTransportTypeCommand : IRequest<DeletedTransportTypeResponse>, ITransactionalRequest
    {
        public Guid Id { get; set; }
    }
}
