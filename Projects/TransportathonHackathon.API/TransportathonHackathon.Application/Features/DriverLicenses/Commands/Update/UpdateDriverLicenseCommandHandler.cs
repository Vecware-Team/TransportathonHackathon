using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions.ExceptionTypes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Commands.Update
{
    public class UpdateDriverLicenseCommandHandler : IRequestHandler<UpdateDriverLicenseCommand, UpdatedDriverLicenseResponse>
    {
        private readonly IDriverLicenseRepository _driverLicenseRepository;
        private readonly IMapper _mapper;

        public UpdateDriverLicenseCommandHandler(IDriverLicenseRepository driverLicenseRepository, IMapper mapper)
        {
            _driverLicenseRepository = driverLicenseRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedDriverLicenseResponse> Handle(UpdateDriverLicenseCommand request, CancellationToken cancellationToken)
        {
            DriverLicense? driverLicense = await _driverLicenseRepository.GetAsync(e => e.DriverId == request.DriverId, include: e => e.Include(e => e.Driver));
            if (driverLicense is null)
                throw new NotFoundException("Driver license not found");

            driverLicense.FirstName = request.FirstName;
            driverLicense.LastName = request.LastName;
            driverLicense.Classes = request.Classes;
            driverLicense.IsNew = request.IsNew;
            driverLicense.LicenseGetDate = request.LicenseGetDate;

            await _driverLicenseRepository.SaveChangesAsync();

            driverLicense.Driver.DriverLicense = null;
            UpdatedDriverLicenseResponse response = _mapper.Map<UpdatedDriverLicenseResponse>(driverLicense);
            return response;
        }
    }
}
