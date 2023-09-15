using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetByCustomerId
{
    public class GetByCustomerIdPaymentRequestQuery : IRequest<Paginate<GetByCustomerIdPaymentRequestResponse>>
    {
        public Guid CustomerId { get; set; }
    }
}
