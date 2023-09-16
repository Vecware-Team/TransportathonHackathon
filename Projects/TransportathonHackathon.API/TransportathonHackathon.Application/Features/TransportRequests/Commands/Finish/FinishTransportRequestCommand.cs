using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish
{
    public class FinishTransportRequestCommand : IRequest<FinishedTransportRequestResponse>, ITransactionalRequest
    {
        public Guid Id { get; set; }
    }

}
