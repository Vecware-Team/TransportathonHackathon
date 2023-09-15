using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Update
{
    public class UpdatePaymentRequestCommandHandler : IRequestHandler<UpdatePaymentRequestCommand, UpdatedPaymentRequestResponse>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public UpdatePaymentRequestCommandHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedPaymentRequestResponse> Handle(UpdatePaymentRequestCommand request, CancellationToken cancellationToken)
        {
            PaymentRequest? paymentRequest = await _paymentRequestRepository.GetAsync(e => e.TransportRequestId == request.TransportRequestId);
            if (paymentRequest is null)
                throw new NotFoundException("Payment request not found");

            paymentRequest.IsPaid = request.IsPaid;
            paymentRequest.Price = request.Price;
            paymentRequest.UpdatedDate = DateTime.UtcNow;

            await _paymentRequestRepository.SaveChangesAsync();

            UpdatedPaymentRequestResponse response = _mapper.Map<UpdatedPaymentRequestResponse>(paymentRequest);
            return response;
        }
    }
}
