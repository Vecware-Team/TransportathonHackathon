using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete
{
    public class DeleteDriverLicenseCommandHandler : IRequestHandler<DeleteDriverLicenseCommand, DeletedDriverLicenseResponse>
    {
        private readonly IDriverLicenseRepository _driverLicenseRepository;
        private readonly IMapper _mapper;

        public DeleteDriverLicenseCommandHandler(IDriverLicenseRepository driverLicenseRepository, IMapper mapper)
        {
            _driverLicenseRepository = driverLicenseRepository;
            _mapper = mapper;
        }

        public async Task<DeletedDriverLicenseResponse> Handle(DeleteDriverLicenseCommand request, CancellationToken cancellationToken)
        {
            DriverLicense? driverLicense = await _driverLicenseRepository.GetAsync(e => e.DriverId == request.DriverId, include: e => e.Include(e => e.Driver));
            if (driverLicense is null)
                throw new NotFoundException("Driver license not found");

            Driver driver = _mapper.Map<Driver>(driverLicense.Driver);
            await _driverLicenseRepository.DeleteAsync(driverLicense, true);

            driver.DriverLicense = null;
            driverLicense.Driver = driver;
            DeletedDriverLicenseResponse response = _mapper.Map<DeletedDriverLicenseResponse>(driverLicense);
            return response;
        }
    }
}
