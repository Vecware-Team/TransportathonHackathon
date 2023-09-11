using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Update
{
    public class UpdatedCarrierResponse
    {
        public Guid EmployeeId { get; set; }
        public Guid CompanyId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool IsOnTransitNow { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
