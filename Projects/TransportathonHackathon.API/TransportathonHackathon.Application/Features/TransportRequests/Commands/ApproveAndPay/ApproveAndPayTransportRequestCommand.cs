using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay
{
    public class ApproveAndPayTransportRequestCommand : IRequest<ApproveAndPayTransportRequestResponse>
    {
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
        public Requests.PaymentRequest PaymentRequest { get; set; }
    }
}
