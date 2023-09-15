using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetByCompanyId
{
    public class GetByCompanyIdPaymentRequestQueryHandler : IRequestHandler<GetByCompanyIdPaymentRequestQuery, Paginate<GetByCompanyIdPaymentRequestResponse>>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public GetByCompanyIdPaymentRequestQueryHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetByCompanyIdPaymentRequestResponse>> Handle(GetByCompanyIdPaymentRequestQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PaymentRequest> paymentRequests = await _paymentRequestRepository.GetListPagedAsync(
                e => e.TransportRequest.CompanyId == request.CompanyId,
                include: e => e.Include(e => e.TransportRequest)
            );

            paymentRequests.Items.ToList().ForEach(e => e.TransportRequest.PaymentRequest = null);
            Paginate<GetByCompanyIdPaymentRequestResponse> response = _mapper.Map<Paginate<GetByCompanyIdPaymentRequestResponse>>(paymentRequests);
            return response;
        }
    }
}
