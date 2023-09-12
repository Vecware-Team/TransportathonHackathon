using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetList
{
    public class GetListPickupTruckQuery : IRequest<Paginate<GetListPickupTruckResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
