using FluentValidation;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Create
{
    public class CreateCarCommandValidator: AbstractValidator<CreateCarCommand>
    {
        public CreateCarCommandValidator()
        {
            RuleFor(e => e.Brand).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.Model).NotNull().NotEmpty().MinimumLength(1);
            RuleFor(e => e.ModelYear).NotNull().GreaterThan(1900);
            RuleFor(e => e.CompanyId).NotNull().NotEmpty();
            RuleFor(e => e.DriverId).NotNull().NotEmpty();
        }
    }
}
