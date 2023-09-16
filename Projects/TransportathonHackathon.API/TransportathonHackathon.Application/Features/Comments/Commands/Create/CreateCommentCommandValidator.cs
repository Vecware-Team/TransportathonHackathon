using FluentValidation;

namespace TransportathonHackathon.Application.Features.Comments.Commands.Create
{
    public class CreateCommentCommandValidator : AbstractValidator<CreateCommentCommand>
    {
        public CreateCommentCommandValidator()
        {
            RuleFor(e => e.Title).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.Description).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.Point).NotNull().GreaterThan(0).LessThanOrEqualTo(5);
            RuleFor(e => e.TransportRequestId).NotNull().NotEmpty();
        }
    }
}
