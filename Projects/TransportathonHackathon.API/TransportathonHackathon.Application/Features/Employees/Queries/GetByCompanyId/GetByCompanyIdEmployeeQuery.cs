using MediatR;

namespace TransportathonHackathon.Application.Features.Employees.Queries.GetByCompanyId
{
    public class GetByCompanyIdEmployeeQuery : IRequest<List<GetByCompanyIdEmployeeResponse>>
    {
        public Guid CompanyId { get; set; }
    }
}
