using FluentValidation;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create
{
    public class CreateDriverLicenseCommandValidator : AbstractValidator<CreateDriverLicenseCommand>
    {
        public CreateDriverLicenseCommandValidator()
        {
            RuleFor(e => e.DriverId).NotNull().NotEmpty();
            RuleFor(e => e.FirstName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(e => e.LastName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(e => e.Classes).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.IsNew).NotNull().NotEmpty();
            RuleFor(e => e.LicenseGetDate).NotNull().NotEmpty();
        }
    }
}
