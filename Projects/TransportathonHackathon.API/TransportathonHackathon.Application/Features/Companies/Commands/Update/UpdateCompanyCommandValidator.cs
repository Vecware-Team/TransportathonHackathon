using FluentValidation;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Update
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        public UpdateCompanyCommandValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.UserName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.CompanyName).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.AppUserId).NotNull().NotEmpty();
        }
    }
}
