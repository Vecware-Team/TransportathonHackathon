using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Create
{
    public class CreateTransportTypeCommandValidator : AbstractValidator<CreateTransportTypeCommand>
    {
        public CreateTransportTypeCommandValidator()
        {
            RuleFor(e => e.Type).NotNull().NotEmpty().MinimumLength(1);
        }
    }
}
