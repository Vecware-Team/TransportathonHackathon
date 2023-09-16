using FluentValidation;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver
{
    public class DeleteDriverCommandValidator : AbstractValidator<DeleteDriverCommand>
    {
        public DeleteDriverCommandValidator()
        {
            RuleFor(e => e.EmployeeId).NotNull().NotEmpty();
        }
    }
}
