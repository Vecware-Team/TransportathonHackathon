using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create
{
    public class CreatePaymentRequestCommand : IRequest<CreatedPaymentRequestResponse>, ITransactionalRequest
    {
        public Guid TransportRequestId { get; set; }
        public decimal Price { get; set; }
    }
}
