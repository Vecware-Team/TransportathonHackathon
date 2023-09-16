using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete
{
    public class DeletePaymentRequestCommand : IRequest<DeletedPaymentRequestResponse>, ITransactionalRequest
    {
        public Guid TransportRequestId { get; set; }
    }
}
