using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetList
{
    public class GetListTransportRequestQueryHandler : IRequestHandler<GetListTransportRequestQuery, Paginate<GetListTransportRequestResponse>>
    {
        private readonly ITransportRequestRepository _transportRequestRepository;
        private readonly IMapper _mapper;

        public GetListTransportRequestQueryHandler(ITransportRequestRepository transportRequestRepository, IMapper mapper)
        {
            _transportRequestRepository = transportRequestRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListTransportRequestResponse>> Handle(GetListTransportRequestQuery request, CancellationToken cancellationToken)
        {
            IPaginate<TransportRequest> transportRequests = await _transportRequestRepository.GetListPagedAsync(include: e => e.Include(e=>e.Company).Include(e=>e.Customer));

            Paginate<GetListTransportRequestResponse> response = _mapper.Map<Paginate<GetListTransportRequestResponse>>(transportRequests);
            return response;
        }
    }
}
