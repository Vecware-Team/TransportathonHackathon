using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetById
{
    public class GetByIdDriverLicenseQueryHandler : IRequestHandler<GetByIdDriverLicenseQuery, GetByIdDriverLicenseResponse>
    {
        private readonly IDriverLicenseRepository _driverLicenseRepository;
        private readonly IMapper _mapper;

        public GetByIdDriverLicenseQueryHandler(IDriverLicenseRepository driverLicenseRepository, IMapper mapper)
        {
            _driverLicenseRepository = driverLicenseRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdDriverLicenseResponse> Handle(GetByIdDriverLicenseQuery request, CancellationToken cancellationToken)
        {
            DriverLicense? driverLicense = await _driverLicenseRepository.GetAsync(e => e.DriverId == request.DriverId, include: e => e.Include(e => e.Driver));
            if (driverLicense is null)
                throw new NotFoundException("Driver license not found");

            driverLicense.Driver.DriverLicense = null;
            GetByIdDriverLicenseResponse response = _mapper.Map<GetByIdDriverLicenseResponse>(driverLicense);
            return response;
        }
    }
}
