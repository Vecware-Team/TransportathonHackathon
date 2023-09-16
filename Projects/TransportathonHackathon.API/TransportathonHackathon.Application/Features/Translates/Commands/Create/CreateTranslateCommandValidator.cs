using FluentValidation;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Create
{
    public class CreateTranslateCommandValidator : AbstractValidator<CreateTranslateCommand>
    {
        public CreateTranslateCommandValidator()
        {
            RuleFor(e => e.LanguageId).NotNull().NotEmpty();
            RuleFor(e => e.Key).NotNull().NotEmpty();
            RuleFor(e => e.Value).NotNull().NotEmpty();
        }
    }
}
