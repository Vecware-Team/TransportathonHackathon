using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Trucks.Queries.GetList
{
    public class GetListTruckQuery : IRequest<Paginate<GetListTruckResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
