using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Delete
{
    public class DeleteTruckCommand : IRequest<DeletedTruckResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid VehicleId { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim };
    }
}
