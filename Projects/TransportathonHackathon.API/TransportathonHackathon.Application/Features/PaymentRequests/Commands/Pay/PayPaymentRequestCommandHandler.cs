using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Application.Services;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Pay
{
    public class PayPaymentRequestCommandHandler : IRequestHandler<PayPaymentRequestCommand, PaidPaymentRequestResponse>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IPaymentService _paymentService;
        private readonly IMapper _mapper;

        public PayPaymentRequestCommandHandler(IPaymentRequestRepository paymentRequestRepository, IPaymentService paymentService, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _paymentService = paymentService;
            _mapper = mapper;
        }

        public async Task<PaidPaymentRequestResponse> Handle(PayPaymentRequestCommand request, CancellationToken cancellationToken)
        {
            PaymentRequest? paymentRequest = await _paymentRequestRepository.GetAsync(e => e.TransportRequestId == request.TransportRequestId);
            if (paymentRequest is null)
                throw new NotFoundException("Payment request not found");

            request.PaymentRequest.Price = paymentRequest.Price;
            if (!await _paymentService.Payment(request.PaymentRequest))
                throw new BusinessException("Payment failed");

            paymentRequest.IsPaid = true;
            await _paymentRequestRepository.SaveChangesAsync();

            PaidPaymentRequestResponse response = _mapper.Map<PaidPaymentRequestResponse>(paymentRequest);
            return response;
        }
    }
}
