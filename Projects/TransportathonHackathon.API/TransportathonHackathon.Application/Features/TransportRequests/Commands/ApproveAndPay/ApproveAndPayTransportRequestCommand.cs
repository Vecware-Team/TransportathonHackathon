﻿using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay
{
    public class ApproveAndPayTransportRequestCommand : IRequest<ApproveAndPayTransportRequestResponse>, ITransactionalRequest, ILoggableRequest, ISecuredRequest
    {
        public Guid Id { get; set; }
        public Guid VehicleId { get; set; }
        public bool IsApproved { get; set; }
        public decimal Price { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim };
    }
}
