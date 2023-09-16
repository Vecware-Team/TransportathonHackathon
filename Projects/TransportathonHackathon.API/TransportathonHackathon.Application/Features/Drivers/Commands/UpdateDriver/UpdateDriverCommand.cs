using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver
{
    public class UpdateDriverCommand : IRequest<UpdatedDriverResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid EmployeeId { get; set; }
        public Guid CompanyId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { new Claim("UserType", "Company") };
    }
}
