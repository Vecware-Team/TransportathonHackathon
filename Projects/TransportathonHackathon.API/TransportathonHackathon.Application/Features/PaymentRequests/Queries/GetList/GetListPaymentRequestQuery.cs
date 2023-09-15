using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetList
{
    public class GetListPaymentRequestQuery : IRequest<Paginate<GetListPaymentRequestResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }

}
