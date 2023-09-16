using FluentValidation;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Update
{
    public class UpdatePaymentRequestCommandValidator : AbstractValidator<UpdatePaymentRequestCommand>
    {
        public UpdatePaymentRequestCommandValidator()
        {
            RuleFor(e => e.TransportRequestId).NotNull().NotEmpty();
            RuleFor(e => e.Price).NotNull().NotEmpty();
        }
    }
}
