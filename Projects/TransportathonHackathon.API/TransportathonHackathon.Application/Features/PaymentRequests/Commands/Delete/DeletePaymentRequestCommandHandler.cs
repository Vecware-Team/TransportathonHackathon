using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Delete
{
    public class DeletePaymentRequestCommandHandler : IRequestHandler<DeletePaymentRequestCommand, DeletedPaymentRequestResponse>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public DeletePaymentRequestCommandHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
        }

        public async Task<DeletedPaymentRequestResponse> Handle(DeletePaymentRequestCommand request, CancellationToken cancellationToken)
        {
            PaymentRequest? paymentRequest = await _paymentRequestRepository.GetAsync(e => e.TransportRequestId == request.TransportRequestId);
            if (paymentRequest is null)
                throw new NotFoundException("Payment request not found");

            await _paymentRequestRepository.DeleteAsync(paymentRequest);

            DeletedPaymentRequestResponse response = _mapper.Map<DeletedPaymentRequestResponse>(paymentRequest);
            return response;
        }
    }
}
