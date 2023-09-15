using AutoMapper;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Commands.Create
{
    public class CreatePaymentRequestCommandHandler : IRequestHandler<CreatePaymentRequestCommand, CreatedPaymentRequestResponse>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public CreatePaymentRequestCommandHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
        }

        public async Task<CreatedPaymentRequestResponse> Handle(CreatePaymentRequestCommand request, CancellationToken cancellationToken)
        {
            PaymentRequest paymentRequest = _mapper.Map<PaymentRequest>(request);
            paymentRequest.IsPaid = false;

            await _paymentRequestRepository.AddAsync(paymentRequest);

            CreatedPaymentRequestResponse response = _mapper.Map<CreatedPaymentRequestResponse>(paymentRequest);
            return response;
        }
    }
}
