using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetList
{
    public class GetListDriverQuery : IRequest<Paginate<GetListDriverResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
