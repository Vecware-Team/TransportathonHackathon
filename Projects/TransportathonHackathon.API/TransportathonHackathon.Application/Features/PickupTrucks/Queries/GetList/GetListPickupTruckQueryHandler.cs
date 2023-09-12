using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetList
{
    public class GetListPickupTruckQueryHandler : IRequestHandler<GetListPickupTruckQuery, Paginate<GetListPickupTruckResponse>>
    {
        private readonly IPickupTruckRepository _pickupTruckRepository;
        private readonly IMapper _mapper;

        public GetListPickupTruckQueryHandler(IPickupTruckRepository pickupTruckRepository, IMapper mapper)
        {
            _pickupTruckRepository = pickupTruckRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListPickupTruckResponse>> Handle(GetListPickupTruckQuery request, CancellationToken cancellationToken)
        {
            IPaginate<PickupTruck> pickupTrucks = await _pickupTruckRepository.GetListPagedAsync(
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver).Include(e => e.Vehicle.Driver.Employee),
                size: request.PageRequest.Size,
                index: request.PageRequest.Index
            );

            Paginate<GetListPickupTruckResponse> response = _mapper.Map<Paginate<GetListPickupTruckResponse>>(pickupTrucks);
            return response;
        }
    }
}
