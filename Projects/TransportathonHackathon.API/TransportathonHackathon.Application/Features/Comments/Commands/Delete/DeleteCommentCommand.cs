using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommand : IRequest<DeletedCommentResponse>, ITransactionalRequest
    {
        public Guid TransportRequestId { get; set; }
    }
}
