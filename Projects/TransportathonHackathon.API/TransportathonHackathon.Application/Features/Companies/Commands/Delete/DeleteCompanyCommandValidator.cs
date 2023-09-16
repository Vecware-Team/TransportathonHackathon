using FluentValidation;

namespace TransportathonHackathon.Application.Features.Companies.Commands.Delete
{
    public class DeleteCompanyCommandValidator : AbstractValidator<DeleteCompanyCommand>
    {
        public DeleteCompanyCommandValidator()
        {
            RuleFor(e => e.AppUserId).NotNull().NotEmpty();
        }
    }
}
