using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve
{
    public class ApproveTransportRequestCommand : IRequest<ApproveTransportRequestResponse>, ITransactionalRequest
    {
        public Guid Id { get; set; }
        public bool IsApproved { get; set; }
    }
}
