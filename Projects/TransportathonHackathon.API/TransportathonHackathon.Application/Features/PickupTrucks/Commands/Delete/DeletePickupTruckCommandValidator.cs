using FluentValidation;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Commands.Delete
{
    public class DeletePickupTruckCommandValidator : AbstractValidator<DeletePickupTruckCommand>
    {
        public DeletePickupTruckCommandValidator()
        {
            RuleFor(e => e.VehicleId).NotNull().NotEmpty();
        }
    }
}
