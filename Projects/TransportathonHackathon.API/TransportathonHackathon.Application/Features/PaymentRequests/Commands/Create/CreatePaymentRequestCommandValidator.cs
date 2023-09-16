using FluentValidation;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create
{
    public class CreatePaymentRequestCommandValidator : AbstractValidator<CreatePaymentRequestCommand>
    {
        public CreatePaymentRequestCommandValidator()
        {
            RuleFor(e => e.TransportRequestId).NotNull().NotEmpty();
            RuleFor(e => e.Price).GreaterThan(2);
        }
    }
}
