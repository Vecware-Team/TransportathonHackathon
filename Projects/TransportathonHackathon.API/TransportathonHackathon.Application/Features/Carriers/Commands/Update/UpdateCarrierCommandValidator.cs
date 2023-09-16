using FluentValidation;

namespace TransportathonHackathon.Application.Features.Carriers.Commands.Update
{
    public class UpdateCarrierCommandValidator : AbstractValidator<UpdateCarrierCommand>
    {
        public UpdateCarrierCommandValidator()
        {
            RuleFor(e => e.Email).NotNull().NotEmpty().EmailAddress();
            RuleFor(e => e.UserName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.FirstName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.LastName).NotNull().NotEmpty().MinimumLength(3);
            RuleFor(e => e.Age).NotNull().GreaterThan(18);
            RuleFor(e => e.CompanyId).NotNull().NotEmpty();
            RuleFor(e => e.EmployeeId).NotNull().NotEmpty();
        }
    }
}
