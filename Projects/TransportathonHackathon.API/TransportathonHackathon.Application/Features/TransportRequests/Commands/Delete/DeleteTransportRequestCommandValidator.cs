using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Delete
{
    public class DeleteTransportRequestCommandValidator : AbstractValidator<DeleteTransportRequestCommand>
    {
        public DeleteTransportRequestCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
