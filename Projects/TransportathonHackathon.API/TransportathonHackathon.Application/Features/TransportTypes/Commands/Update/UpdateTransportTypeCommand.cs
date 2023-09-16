using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Update
{
    public class UpdateTransportTypeCommand : IRequest<UpdatedTransportTypeResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public string[] Roles => new string[] { "Admin" };
        public Claim[] Claims => new Claim[] { };
    }
}
