using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PaymentRequests.Queries.GetList
{
    public class GetListPaymentRequestQueryHandler : IRequestHandler<GetListPaymentRequestQuery, Paginate<GetListPaymentRequestResponse>>
    {
        private readonly IPaymentRequestRepository _paymentRequestRepository;
        private readonly IMapper _mapper;

        public GetListPaymentRequestQueryHandler(IPaymentRequestRepository paymentRequestRepository, IMapper mapper)
        {
            _paymentRequestRepository = paymentRequestRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListPaymentRequestResponse>> Handle(GetListPaymentRequestQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PaymentRequest> paymentRequests = await _paymentRequestRepository.GetListPagedAsync(
                index: request.PageRequest.Index,
                size: request.PageRequest.Size
            );

            Paginate<GetListPaymentRequestResponse> response = _mapper.Map<Paginate<GetListPaymentRequestResponse>>(paymentRequests);
            return response;
        }
    }

}
