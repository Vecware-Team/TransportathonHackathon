using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Delete
{
    public class DeleteTransportTypeCommandValidator : AbstractValidator<DeleteTransportTypeCommand>
    {
        public DeleteTransportTypeCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
