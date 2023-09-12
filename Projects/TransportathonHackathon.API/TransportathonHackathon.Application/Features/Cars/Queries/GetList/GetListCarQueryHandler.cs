using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Cars.Queries.GetList
{
    public class GetListCarQueryHandler : IRequestHandler<GetListCarQuery, Paginate<GetListCarResponse>>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetListCarQueryHandler(ICarRepository repository, IMapper mapper)
        {
            _carRepository = repository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetListCarResponse>> Handle(GetListCarQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Car> cars = await _carRepository.GetListPagedAsync(
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver),
                size: request.PageRequest.Size,
                index: request.PageRequest.Index
            );

            Paginate<GetListCarResponse> response = _mapper.Map<Paginate<GetListCarResponse>>(cars);
            return response;
        }
    }

}
