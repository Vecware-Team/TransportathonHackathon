using FluentValidation;

namespace TransportathonHackathon.Application.Features.Customers.Commands.Create
{
    public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.UserName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.FirstName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.LastName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.Password).NotNull().NotEmpty().MinimumLength(6);
        }
    }
}
