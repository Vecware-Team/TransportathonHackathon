using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Create;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Delete;
using TransportathonHackathon.Application.Features.DriverLicenses.Commands.Update;
using TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetById;
using TransportathonHackathon.Application.Features.DriverLicenses.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.DriverLicenses.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DriverLicense, CreateDriverLicenseCommand>().ReverseMap();
            CreateMap<DriverLicense, CreatedDriverLicenseResponse>().ReverseMap();

            CreateMap<DriverLicense, DeletedDriverLicenseResponse>().ReverseMap();

            CreateMap<DriverLicense, UpdateDriverLicenseCommand>().ReverseMap();
            CreateMap<DriverLicense, UpdatedDriverLicenseResponse>().ReverseMap();

            CreateMap<DriverLicense, GetByIdDriverLicenseResponse>().ReverseMap();

            CreateMap<DriverLicense, GetListDriverLicenseResponse>().ReverseMap();
            CreateMap<Paginate<DriverLicense>, Paginate<GetListDriverLicenseResponse>>().ReverseMap();
        }
    }
}
