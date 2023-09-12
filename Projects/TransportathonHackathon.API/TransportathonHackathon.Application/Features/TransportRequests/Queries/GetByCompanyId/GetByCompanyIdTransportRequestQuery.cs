using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyId
{
    public class GetByCompanyIdTransportRequestQuery : IRequest<List<GetByCompanyIdTransportRequestResponse>>
    {
        public Guid CompanyId { get; set; }
    }
}
