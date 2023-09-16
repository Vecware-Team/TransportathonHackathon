using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Finish
{
    public class FinishTransportRequestCommandValidator : AbstractValidator<FinishTransportRequestCommand>
    {
        public FinishTransportRequestCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
        }
    }
}
