using FluentValidation;

namespace TransportathonHackathon.Application.Features.TransportRequests.Commands.ApproveAndPay
{
    public class ApproveAndPayTransportRequestCommandValidator : AbstractValidator<ApproveAndPayTransportRequestCommand>
    {
        public ApproveAndPayTransportRequestCommandValidator()
        {
            RuleFor(e => e.Id).NotNull().NotEmpty();
            RuleFor(e => e.IsApproved).NotNull().NotEmpty();
            RuleFor(e => e.Price).NotNull().NotEmpty().GreaterThan(2);
        }
    }
}
