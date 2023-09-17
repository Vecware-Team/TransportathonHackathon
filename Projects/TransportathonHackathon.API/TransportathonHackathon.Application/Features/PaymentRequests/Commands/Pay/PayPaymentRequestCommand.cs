using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;
using TransportathonHackathon.Application.Constants;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay
{
    public class PayPaymentRequestCommand : IRequest<PaidPaymentRequestResponse>, ITransactionalRequest, ILoggableRequest, ISecuredRequest
    {
        public Guid TransportRequestId { get; set; }
        public Requests.PaymentRequest PaymentRequest { get; set; }

        public string[] Roles => new string[] { };
        public Claim[] Claims => new Claim[] { ProjectClaimConstants.CustomerClaim };
    }
}
