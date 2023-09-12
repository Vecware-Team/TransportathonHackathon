using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Cars.Queries.GetById
{
    public class GetByIdCarQueryHandler : IRequestHandler<GetByIdCarQuery, GetByIdCarResponse>
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public GetByIdCarQueryHandler(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCarResponse> Handle(GetByIdCarQuery request, CancellationToken cancellationToken)
        {
            Car? car = await _carRepository.GetAsync(
                e => e.VehicleId == request.VehicleId,
                include: e => e.Include(e => e.Vehicle).Include(e => e.Vehicle.Company).Include(e => e.Vehicle.Driver)
            );
            if (car is null)
                throw new NotFoundException("Car not found");

            GetByIdCarResponse response = _mapper.Map<GetByIdCarResponse>(car);
            return response;
        }
    }
}
