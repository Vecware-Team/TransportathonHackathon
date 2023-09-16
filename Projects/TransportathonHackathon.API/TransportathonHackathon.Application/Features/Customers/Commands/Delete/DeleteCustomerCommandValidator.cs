using FluentValidation;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Delete
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(e => e.AppUserId).NotNull().NotEmpty();
        }
    }
}
