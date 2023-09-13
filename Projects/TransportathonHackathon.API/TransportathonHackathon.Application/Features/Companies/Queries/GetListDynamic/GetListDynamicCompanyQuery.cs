using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetListDynamic
{
    public class GetListDynamicCompanyQuery : IRequest<Paginate<GetListDynamicCompanyResponse>>
    {
        public DynamicQuery DynamicQuery { get; set; }
        public PageRequest PageRequest { get; set; } = new();
    }
}
