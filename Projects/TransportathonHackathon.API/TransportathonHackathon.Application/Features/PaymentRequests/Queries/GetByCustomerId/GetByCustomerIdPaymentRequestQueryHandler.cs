using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetByCustomerId
{
    public class GetByCustomerIdPaymentRequestQueryHandler : IRequestHandler<GetByCustomerIdPaymentRequestQuery, Paginate<GetByCustomerIdPaymentRequestResponse>>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public GetByCustomerIdPaymentRequestQueryHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetByCustomerIdPaymentRequestResponse>> Handle(GetByCustomerIdPaymentRequestQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PaymentRequest> paymentRequests = await _paymentRequestRepository.GetListPagedAsync(
                e => e.TransportRequest.CustomerId == request.CustomerId,
                include: e => e.Include(e => e.TransportRequest)
            );

            paymentRequests.Items.ToList().ForEach(e => e.TransportRequest.PaymentRequest = null);
            Paginate<GetByCustomerIdPaymentRequestResponse> response = _mapper.Map<Paginate<GetByCustomerIdPaymentRequestResponse>>(paymentRequests);
            return response;
        }
    }
}
