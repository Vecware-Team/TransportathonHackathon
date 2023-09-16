using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Create
{
    public class CreateCommentCommand : IRequest<CreatedCommentResponse>, ITransactionalRequest
    {
        public Guid TransportRequestId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Point { get; set; }
    }
}
