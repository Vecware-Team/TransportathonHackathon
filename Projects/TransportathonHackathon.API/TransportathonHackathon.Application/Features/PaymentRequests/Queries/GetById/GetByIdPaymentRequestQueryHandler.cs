using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetById
{
    public class GetByIdPaymentRequestQueryHandler : IRequestHandler<GetByIdPaymentRequestQuery, GetByIdPaymentRequestResponse>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public GetByIdPaymentRequestQueryHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdPaymentRequestResponse> Handle(GetByIdPaymentRequestQuery request, CancellationToken cancellationToken)
        {
            PaymentRequest? paymentRequest = await _paymentRequestRepository.GetAsync(e => e.TransportRequestId == request.TransportRequestId);
            if (paymentRequest is null)
                throw new NotFoundException("Payment request not found");

            GetByIdPaymentRequestResponse response = _mapper.Map<GetByIdPaymentRequestResponse>(paymentRequest);
            return response;
        }
    }
}
