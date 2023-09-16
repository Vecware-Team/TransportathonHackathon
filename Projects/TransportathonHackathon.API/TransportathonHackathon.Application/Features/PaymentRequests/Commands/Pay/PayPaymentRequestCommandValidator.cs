using FluentValidation;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay
{
    public class PayPaymentRequestCommandValidator : AbstractValidator<PayPaymentRequestCommand>
    {
        public PayPaymentRequestCommandValidator()
        {
            RuleFor(e => e.TransportRequestId).NotNull().NotEmpty();
            RuleFor(e => e.PaymentRequest.CardNumber).NotNull().NotEmpty().Must(e => e.Length == 16);
            RuleFor(e => e.PaymentRequest.Month).NotNull().NotEmpty().Must(e => e.ToString().Length == 2);
            RuleFor(e => e.PaymentRequest.Year).NotNull().NotEmpty().Must(e => e.ToString().Length == 4);
            RuleFor(e => e.PaymentRequest.FullName).NotNull().NotEmpty().MinimumLength(2);
            RuleFor(e => e.PaymentRequest.CVV).NotNull().NotEmpty().Must(e => e.ToString().Length == 3);
        }
    }
}
