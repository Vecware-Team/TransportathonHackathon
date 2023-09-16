using FluentValidation;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Delete
{
    public class DeleteTranslateCommandValidator : AbstractValidator<DeleteTranslateCommand>
    {
        public DeleteTranslateCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
