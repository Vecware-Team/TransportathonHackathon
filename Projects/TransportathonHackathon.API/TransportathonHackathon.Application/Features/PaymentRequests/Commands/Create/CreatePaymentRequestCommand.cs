﻿using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create
{
    public class CreatePaymentRequestCommand : IRequest<CreatedPaymentRequestResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid TransportRequestId { get; set; }
        public decimal Price { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CompanyClaim };
    }
}
