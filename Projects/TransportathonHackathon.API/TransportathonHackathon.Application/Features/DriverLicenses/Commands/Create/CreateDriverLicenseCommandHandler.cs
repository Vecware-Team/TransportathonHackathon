using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Application.Requests;
using TransportathonHackathon.Application.Services;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create
{
    public class CreateDriverLicenseCommandHandler : IRequestHandler<CreateDriverLicenseCommand, CreatedDriverLicenseResponse>
    {
        private readonly IDriverLicenseRepository _driverLicenseRepository;
        private readonly IDriverLicenseVerifierService _driverLicenseVerifierService;
        private readonly IMapper _mapper;

        public CreateDriverLicenseCommandHandler(IDriverLicenseRepository driverLicenseRepository, IDriverLicenseVerifierService driverLicenseVerifierService, IMapper mapper)
        {
            _driverLicenseRepository = driverLicenseRepository;
            _driverLicenseVerifierService = driverLicenseVerifierService;
            _mapper = mapper;
        }

        public async Task<CreatedDriverLicenseResponse> Handle(CreateDriverLicenseCommand request, CancellationToken cancellationToken)
        {
            DriverLicense driverLicense = _mapper.Map<DriverLicense>(request);

            bool result = await _driverLicenseVerifierService.Verify(_mapper.Map<DriverLicenseRequest>(driverLicense));
            if (!result)
                throw new BusinessException("Driver license is not valid");

            await _driverLicenseRepository.AddAsync(driverLicense);

            driverLicense = await _driverLicenseRepository.GetAsync(e => e.DriverId == driverLicense.DriverId, include: e => e.Include(e => e.Driver));

            driverLicense.Driver.DriverLicense = null;
            CreatedDriverLicenseResponse response = _mapper.Map<CreatedDriverLicenseResponse>(driverLicense);
            return response;
        }
    }

}
