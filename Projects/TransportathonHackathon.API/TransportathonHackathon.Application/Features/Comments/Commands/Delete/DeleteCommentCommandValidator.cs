using FluentValidation;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Delete
{
    public class DeleteCommentCommandValidator : AbstractValidator<DeleteCommentCommand>
    {
        public DeleteCommentCommandValidator()
        {
            RuleFor(e => e.TransportRequestId).NotNull().NotEmpty();
        }
    }
}
