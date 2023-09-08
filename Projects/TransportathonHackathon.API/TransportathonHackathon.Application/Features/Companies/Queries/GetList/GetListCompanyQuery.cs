using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetList
{
    public class GetListCompanyQuery : IRequest<IPaginate<GetListCompanyResponse>>
    {
        public PageRequest PageRequest { get; set; } = new();
    }
}
