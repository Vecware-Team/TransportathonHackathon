using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Queries.GetListDynamic
{
    public class GetListDynamicCompanyResponse
    {
        public Guid AppUserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string CompanyName { get; set; }
        public int DriverCount { get; set; }
        public int CompletedJobsCount { get; set; }
        public IEnumerable<Employee>? Employees { get; set; }
    }
}
