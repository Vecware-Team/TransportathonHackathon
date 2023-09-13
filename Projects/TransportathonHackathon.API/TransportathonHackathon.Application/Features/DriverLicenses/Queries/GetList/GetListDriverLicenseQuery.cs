using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetList
{
    public class GetListDriverLicenseQuery : IRequest<Paginate<GetListDriverLicenseResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
