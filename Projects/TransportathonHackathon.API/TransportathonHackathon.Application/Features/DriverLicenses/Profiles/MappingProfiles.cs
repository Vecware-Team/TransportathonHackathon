using AutoMapper;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DriverLicense, CreateDriverLicenseCommand>().ReverseMap();
            CreateMap<DriverLicense, CreatedDriverLicenseResponse>().ReverseMap();
        }
    }
}
