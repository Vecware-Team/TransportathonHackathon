using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCustomerId
{
    public class GetByCustomerIdTransportRequestQueryHandler : IRequestHandler<GetByCustomerIdTransportRequestQuery, List<GetByCustomerIdTransportRequestResponse>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetByCustomerIdTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCustomerIdTransportRequestResponse>> Handle(GetByCustomerIdTransportRequestQuery request, CancellationToken cancellationToken)
        {
            IList<TransportRequest> transportRequest = await _transportRequestRepository.GetListAsync(
                e => e.CustomerId == request.CustomerId,
                include: e => e.Include(e => e.Company).Include(e => e.Customer)
            );

            List<GetByCustomerIdTransportRequestResponse> response = _mapper.Map<List<GetByCustomerIdTransportRequestResponse>>(transportRequest.ToList());
            return response;
        }
    }
}
