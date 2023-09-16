using FluentValidation;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommandValidator : AbstractValidator<UpdateLanguageCommand>
    {
        public UpdateLanguageCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
            RuleFor(e => e.Code).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(e => e.GloballyName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(e => e.LocallyName).NotNull().NotEmpty().MinimumLength(2);
        }
    }
}
