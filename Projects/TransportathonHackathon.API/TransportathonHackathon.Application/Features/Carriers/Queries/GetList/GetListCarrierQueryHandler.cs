using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Carriers.Queries.GetList
{
    public class GetListCarrierQueryHandler : IRequestHandler<GetListCarrierQuery, Paginate<GetListCarrierResponse>>
    {
        private readonly ICarrierRepository _carrierRepository;
        private readonly IMapper _mapper;

        public GetListCarrierQueryHandler(ICarrierRepository carrierRepository, IMapper mapper)
        {
            _carrierRepository = carrierRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListCarrierResponse>> Handle(GetListCarrierQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Carrier> carriers = await _carrierRepository.GetListPagedAsync(
                include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser),
                size: request.PageRequest.Size,
                index: request.PageRequest.Index
            );

            Paginate<GetListCarrierResponse> response = _mapper.Map<Paginate<GetListCarrierResponse>>(carriers);

            return response;
        }
    }
}
