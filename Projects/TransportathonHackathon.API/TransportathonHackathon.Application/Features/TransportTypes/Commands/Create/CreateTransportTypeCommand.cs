using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using Core.Security.Constants;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Create
{
    public class CreateTransportTypeCommand : IRequest<CreatedTransportTypeResponse>, ITransactionalRequest, ISecuredRequest
    {
        public string Type { get; set; }

        public string[] Roles => new string[] { RoleConstants.Admin };
        public Claim[] Claims => new Claim[] { ClaimConstants.AdminClaim };
    }
}
