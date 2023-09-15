using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetByCompanyId
{
    public class GetByCompanyIdPaymentRequestQuery : IRequest<Paginate<GetByCompanyIdPaymentRequestResponse>>
    {
        public Guid CompanyId { get; set; }
    }
}
