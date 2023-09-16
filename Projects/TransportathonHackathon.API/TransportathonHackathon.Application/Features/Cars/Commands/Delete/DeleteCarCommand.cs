using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommand : IRequest<DeletedCarResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid VehicleId { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { new Claim("UserType", "Company") };
    }
}
