using FluentValidation;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Delete
{
    public class DeleteCarrierCommandValidator : AbstractValidator<DeleteCarrierCommand>
    {
        public DeleteCarrierCommandValidator()
        {
            RuleFor(e => e.EmployeeId).NotNull().NotEmpty();
        }
    }
}
