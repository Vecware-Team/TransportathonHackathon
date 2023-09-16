using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay
{
    public class PayPaymentRequestCommand : IRequest<PaidPaymentRequestResponse>, ITransactionalRequest
    {
        public Guid TransportRequestId { get; set; }
        public Requests.PaymentRequest PaymentRequest { get; set; }
    }
}
