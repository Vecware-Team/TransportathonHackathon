using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetByCompanyId
{
    public class GetByCompanyIdTransportRequestQueryHandler : IRequestHandler<GetByCompanyIdTransportRequestQuery, List<GetByCompanyIdTransportRequestResponse>>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetByCompanyIdTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByCompanyIdTransportRequestResponse>> Handle(GetByCompanyIdTransportRequestQuery request, CancellationToken cancellationToken)
        {
            IList<TransportRequest> transportRequest = await _transportRequestRepository.GetListAsync(
                e => e.CompanyId == request.CompanyId,
                include: e => e.Include(e => e.Company).Include(e => e.Customer)
            );

            List<GetByCompanyIdTransportRequestResponse> response = _mapper.Map<List<GetByCompanyIdTransportRequestResponse>>(transportRequest.ToList());
            return response;
        }
    }
}
