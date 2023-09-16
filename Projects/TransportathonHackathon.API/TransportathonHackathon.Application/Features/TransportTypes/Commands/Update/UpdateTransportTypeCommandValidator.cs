using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Update
{
    public class UpdateTransportTypeCommandValidator : AbstractValidator<UpdateTransportTypeCommand>
    {
        public UpdateTransportTypeCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
            RuleFor(e => e.Type).NotNull().NotEmpty().MinimumLength(1);
        }
    }
}
