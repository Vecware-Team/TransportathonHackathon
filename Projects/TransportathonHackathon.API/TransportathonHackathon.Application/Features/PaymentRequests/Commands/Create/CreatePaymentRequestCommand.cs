using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create
{
    public class CreatePaymentRequestCommand : IRequest<CreatedPaymentRequestResponse>
    {
        public Guid TransportRequestId { get; set; }
        public decimal Price { get; set; }
    }
}
