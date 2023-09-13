using MediatR;

namespace TransportathonHackathon.Application.Features.Carriers.Queries.GetByCompanyId
{
    public class GetByCompanyIdCarrierQuery : IRequest<List<GetByCompanyIdCarrierResponse>>
    {
        public Guid CompanyId { get; set; }
    }
}
