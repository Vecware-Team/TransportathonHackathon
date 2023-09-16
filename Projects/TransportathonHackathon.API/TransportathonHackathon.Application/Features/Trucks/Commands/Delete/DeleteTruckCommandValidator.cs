using FluentValidation;

namespace TransportathonHackathon.Application.Features.Trucks.Commands.Delete
{
    public class DeleteTruckCommandValidator : AbstractValidator<DeleteTruckCommand>
    {
        public DeleteTruckCommandValidator()
        {
            RuleFor(e => e.VehicleId).NotNull().NotEmpty();
        }
    }
}
