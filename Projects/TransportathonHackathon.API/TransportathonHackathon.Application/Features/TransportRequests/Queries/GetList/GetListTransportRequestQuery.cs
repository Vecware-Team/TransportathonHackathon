using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetList
{
    public class GetListTransportRequestQuery : IRequest<Paginate<GetListTransportRequestResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
