using FluentValidation;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Update
{
    public class UpdateTranslateCommandValidator : AbstractValidator<UpdateTranslateCommand>
    {
        public UpdateTranslateCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
            RuleFor(e => e.LanguageId).NotNull().NotEmpty();
            RuleFor(e => e.Key).NotNull().NotEmpty();
            RuleFor(e => e.Value).NotNull().NotEmpty();
        }
    }
}
