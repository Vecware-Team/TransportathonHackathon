using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyAndCustomer
{
    public class GetByCompanyAndCustomerTransportRequestQueryHandler : IRequestHandler<GetByCompanyAndCustomerTransportRequestQuery, List<GetByCompanyAndCustomerTransportRequestResponse>>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetByCompanyAndCustomerTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCompanyAndCustomerTransportRequestResponse>> Handle(GetByCompanyAndCustomerTransportRequestQuery request, CancellationToken cancellationToken)
        {
            IList<TransportRequest> transportRequests = await _transportRequestRepository.GetListAsync(
                e => e.CompanyId == request.CompanyId && e.CustomerId == request.CustomerId && e.IsFinished && e.Comment == null,
                include: e => e.Include(e => e.Company).Include(e => e.Customer).Include(e => e.TransportType).Include(e => e.PaymentRequest).Include(e => e.Comment)
            );

            transportRequests.ToList().ForEach(e =>
            {
                if (e.PaymentRequest is not null) e.PaymentRequest.TransportRequest = null;
            });

            List<GetByCompanyAndCustomerTransportRequestResponse> response = _mapper.Map<List<GetByCompanyAndCustomerTransportRequestResponse>>(transportRequests.ToList());
            return response;
        }
    }
}
