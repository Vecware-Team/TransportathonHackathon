using FluentValidation;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Create
{
    public class CreateLanguageCommandValidator : AbstractValidator<CreateLanguageCommand>
    {
        public CreateLanguageCommandValidator()
        {
            RuleFor(e => e.Code).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(e => e.GloballyName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(e => e.LocallyName).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
