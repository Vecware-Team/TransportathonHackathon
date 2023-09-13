using MediatR;
using System.Collections.Generic;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetByCompanyId
{
    public class GetByCompanyIdDriverQuery : IRequest<List<GetByCompanyIdDriverResponse>>
    {
        public Guid CompanyId { get; set; }
    }
}
