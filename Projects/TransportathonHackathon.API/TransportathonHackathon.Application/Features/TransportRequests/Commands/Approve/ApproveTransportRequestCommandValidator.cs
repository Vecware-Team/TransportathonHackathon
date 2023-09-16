using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.Approve
{
    public class ApproveTransportRequestCommandValidator:AbstractValidator<ApproveTransportRequestCommand>
    {
        public ApproveTransportRequestCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
            RuleFor(e => e.IsApproved).NotNull().NotEmpty();
        }
    }
}
