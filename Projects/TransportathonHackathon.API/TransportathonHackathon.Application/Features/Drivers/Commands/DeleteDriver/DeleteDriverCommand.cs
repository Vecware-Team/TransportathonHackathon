using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverCommand : IRequest<DeletedDriverResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid EmployeeId { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim };
    }
}
