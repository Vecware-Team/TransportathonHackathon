using FluentValidation;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommandValidator : AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
