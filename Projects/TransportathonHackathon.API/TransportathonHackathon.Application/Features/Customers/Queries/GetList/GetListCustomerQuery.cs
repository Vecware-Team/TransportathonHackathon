using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Customers.Queries.GetList
{
    public class GetListCustomerQuery : IRequest<Paginate<GetListCustomerResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
