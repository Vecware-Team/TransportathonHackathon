using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish
{
    public class FinishTransportRequestCommand : IRequest<FinishedTransportRequestResponse>, ITransactionalRequest, ILoggableRequest
    {
        public Guid Id { get; set; }
    }
}
