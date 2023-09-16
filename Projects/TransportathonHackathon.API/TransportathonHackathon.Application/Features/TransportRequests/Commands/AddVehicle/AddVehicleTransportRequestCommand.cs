using Core.Application.Pipelines.Authorization;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.AddVehicle
{
    public class AddVehicleTransportRequestCommand : IRequest<AddVehicleTransportRequestResponse>, ISecuredRequest
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { new Claim("UserType", "Company") };
    }
}
