using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.Queries.GetById
{
    public class GetByIdDriverQueryHandler : IRequestHandler<GetByIdDriverQuery, GetByIdDriverResponse>
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public GetByIdDriverQueryHandler(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdDriverResponse> Handle(GetByIdDriverQuery request, CancellationToken cancellationToken)
        {
            Driver? driver = await _driverRepository.GetAsync(
                e => e.EmployeeId == request.EmployeeId,
                include: e => e.Include(e => e.Employee).Include(e => e.Employee.Company).Include(e => e.Employee.AppUser).Include(e => e.DriverLicense)
            );
            if (driver is null)
                throw new NotFoundException("Driver not found");

            GetByIdDriverResponse response = _mapper.Map<GetByIdDriverResponse>(driver);
            return response;
        }
    }
}
