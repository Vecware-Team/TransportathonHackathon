using FluentValidation;

namespace TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver
{
    public class CreateDriverCommandValidator : AbstractValidator<CreateDriverCommand>
    {
        public CreateDriverCommandValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.UserName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.FirstName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.LastName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.Password).NotNull().NotEmpty().MinimumLength(6);
            RuleFor(e => e.Age).NotNull().GreaterThan(18);
            RuleFor(e => e.CompanyId).NotNull().NotEmpty();
        }
    }
}
