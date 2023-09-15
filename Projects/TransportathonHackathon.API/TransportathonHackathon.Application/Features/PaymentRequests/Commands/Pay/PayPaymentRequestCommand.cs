using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay
{
    public class PayPaymentRequestCommand : IRequest<PaidPaymentRequestResponse>
    {
        public Guid TransportRequestId { get; set; }
        public Requests.PaymentRequest PaymentRequest { get; set; }
    }
}
