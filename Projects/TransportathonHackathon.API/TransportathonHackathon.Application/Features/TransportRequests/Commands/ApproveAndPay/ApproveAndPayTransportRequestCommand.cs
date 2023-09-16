using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay
{
    public class ApproveAndPayTransportRequestCommand : IRequest<ApproveAndPayTransportRequestResponse>, ITransactionalRequest, ILoggableRequest
    {
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public decimal Price { get; set; }
    }
}
