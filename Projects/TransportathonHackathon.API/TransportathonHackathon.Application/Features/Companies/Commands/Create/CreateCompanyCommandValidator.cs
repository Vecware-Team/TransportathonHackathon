using FluentValidation;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Create
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        public CreateCompanyCommandValidator()
        {
            RuleFor(e => e.CompanyName).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.UserName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.Password).NotNull().NotEmpty().MinimumLength(6);
        }
    }
}
