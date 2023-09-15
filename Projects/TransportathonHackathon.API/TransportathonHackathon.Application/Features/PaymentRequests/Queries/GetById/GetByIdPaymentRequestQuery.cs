using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetById
{
    public class GetByIdPaymentRequestQuery : IRequest<GetByIdPaymentRequestResponse>
    {
        public Guid TransportRequestId { get; set; }
    }
}
