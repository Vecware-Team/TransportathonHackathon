using FluentValidation;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete
{
    public class DeleteDriverLicenseCommandValidator : AbstractValidator<DeleteDriverLicenseCommand>
    {
        public DeleteDriverLicenseCommandValidator()
        {
            RuleFor(e => e.DriverId).NotNull().NotEmpty();
        }
    }
}
