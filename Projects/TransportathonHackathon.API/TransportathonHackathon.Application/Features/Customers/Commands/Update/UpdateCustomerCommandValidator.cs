using FluentValidation;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Update
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.UserName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.FirstName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.LastName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.AppUserId).NotNull().NotEmpty();
        }
    }
}
