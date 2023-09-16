using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Update
{
    public class UpdatePaymentRequestCommand : IRequest<UpdatedPaymentRequestResponse>, ITransactionalRequest
    {
        public Guid TransportRequestId { get; set; }
        public bool IsPaid { get; set; }
        public decimal Price { get; set; }
    }
}
