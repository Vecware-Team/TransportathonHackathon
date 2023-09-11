using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Carriers.Queries.GetList
{
    public class GetListCarrierQuery : IRequest<Paginate<GetListCarrierResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
