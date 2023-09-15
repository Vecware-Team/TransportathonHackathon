using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete
{
    public class DeletePaymentRequestCommand : IRequest<DeletedPaymentRequestResponse>
    {
        public Guid TransportRequestId { get; set; }
    }
}
