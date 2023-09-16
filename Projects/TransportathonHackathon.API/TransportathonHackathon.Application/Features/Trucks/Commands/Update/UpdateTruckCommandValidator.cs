using FluentValidation;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Update
{
    public class UpdateTruckCommandValidator : AbstractValidator<UpdateTruckCommand>
    {
        public UpdateTruckCommandValidator()
        {
            RuleFor(e => e.CompanyId).NotNull().NotEmpty();
            RuleFor(e => e.VehicleId).NotNull().NotEmpty();
            RuleFor(e => e.DriverId).NotNull().NotEmpty();
            RuleFor(e => e.Brand).NotNull().NotEmpty();
            RuleFor(e => e.Model).NotNull().NotEmpty();
            RuleFor(e => e.Size).NotNull().NotEmpty();
            RuleFor(e => e.ModelYear).NotNull().NotEmpty().GreaterThan(1900);
        }
    }
}
