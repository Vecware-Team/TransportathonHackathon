using FluentValidation;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete
{
    public class DeletePaymentRequestCommandValidator : AbstractValidator<DeletePaymentRequestCommand>
    {
        public DeletePaymentRequestCommandValidator()
        {
            RuleFor(e => e.TransportRequestId).NotNull().NotEmpty();
        }
    }
}
