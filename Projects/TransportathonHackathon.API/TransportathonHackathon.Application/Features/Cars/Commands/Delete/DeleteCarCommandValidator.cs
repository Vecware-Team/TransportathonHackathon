using FluentValidation;

namespace TransportathonHackathon.Application.Features.Cars.Commands.Delete
{
    public class DeleteCarCommandValidator : AbstractValidator<DeleteCarCommand>
    {
        public DeleteCarCommandValidator()
        {
            RuleFor(e => e.VehicleId).NotNull().NotEmpty();
        }
    }
}
