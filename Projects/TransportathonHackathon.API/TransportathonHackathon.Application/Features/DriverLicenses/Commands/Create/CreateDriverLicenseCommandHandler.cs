using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create
{
    public class CreateDriverLicenseCommandHandler : IRequestHandler<CreateDriverLicenseCommand, CreatedDriverLicenseResponse>
    {
        private readonly IDriverLicenseRepository _driverLicenseRepository;
        private readonly IMapper _mapper;

        public CreateDriverLicenseCommandHandler(IDriverLicenseRepository driverLicenseRepository, IMapper mapper)
        {
            _driverLicenseRepository = driverLicenseRepository;
            _mapper = mapper;
        }

        public async Task<CreatedDriverLicenseResponse> Handle(CreateDriverLicenseCommand request, CancellationToken cancellationToken)
        {
            DriverLicense driverLicense = _mapper.Map<DriverLicense>(request);

            await _driverLicenseRepository.AddAsync(driverLicense);

            driverLicense = await _driverLicenseRepository.GetAsync(e => e.DriverId == driverLicense.DriverId, include: e => e.Include(e => e.Driver));

            CreatedDriverLicenseResponse response = _mapper.Map<CreatedDriverLicenseResponse>(driverLicense);
            return response;
        }
    }

}
