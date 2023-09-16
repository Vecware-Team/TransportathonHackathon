using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete
{
    public class DeleteTransportTypeCommand : IRequest<DeletedTransportTypeResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid Id { get; set; }

        public string[] Roles => new string[] { "Admin" };
        public Claim[] Claims => new Claim[] { };
    }
}
