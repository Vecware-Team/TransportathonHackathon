using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Rules
{
    public class CommentBusinessRules : BaseBusinessRules
    {
        private readonly ICommentRepository _commentRepository;

        public CommentBusinessRules(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task CommentIdCannotBeDuplicatedWhenInserting(Guid id)
        {
            Comment? comment = await _commentRepository.GetAsync(e => e.TransportRequestId == id);
            if (comment is not null)
                throw new BusinessException("Comment already exists for the transport request");
        }
    }
}
