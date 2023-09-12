using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Trucks.Queries.GetList
{
    public class GetListTruckQueryHandler : IRequestHandler<GetListTruckQuery, Paginate<GetListTruckResponse>>
    {
        private readonly ITruckRepository _truckRepository;
        private readonly IMapper _mapper;

        public GetListTruckQueryHandler(ITruckRepository truckRepository, IMapper mapper)
        {
            _truckRepository = truckRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListTruckResponse>> Handle(GetListTruckQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Truck> trucks = await _truckRepository.GetListPagedAsync(
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee),
                size: request.PageRequest.Size,
                index: request.PageRequest.Index
            );

            Paginate<GetListTruckResponse> response = _mapper.Map<Paginate<GetListTruckResponse>>(trucks);
            return response;
        }
    }
}
