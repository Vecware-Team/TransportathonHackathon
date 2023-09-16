using FluentValidation;
using TransportathonHackathon.Application.Features.Trucks.Commands.Create;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Create
{
    public class CreateTruckCommandValidator : AbstractValidator<CreateTruckCommand>
    {
        public CreateTruckCommandValidator()
        {
            RuleFor(e => e.CompanyId).NotNull().NotEmpty();
            RuleFor(e => e.DriverId).NotNull().NotEmpty();
            RuleFor(e => e.Brand).NotNull().NotEmpty();
            RuleFor(e => e.Model).NotNull().NotEmpty();
            RuleFor(e => e.ModelYear).NotNull().NotEmpty().GreaterThan(1900);
        }
    }
}
