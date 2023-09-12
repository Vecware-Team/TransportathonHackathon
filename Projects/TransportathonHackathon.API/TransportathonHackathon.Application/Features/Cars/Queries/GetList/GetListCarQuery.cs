using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Cars.Queries.GetList
{
    public class GetListCarQuery : IRequest<Paginate<GetListCarResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }

}
