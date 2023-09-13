using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Employees.Queries.GetByCompanyId
{
    public class GetByCompanyIdEmployeeResponse
    {
        public Guid AppUserId { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsOnTransitNow { get; set; }

        public virtual Carrier? Carrier { get; set; }
        public virtual Driver? Driver { get; set; }
    }
}
