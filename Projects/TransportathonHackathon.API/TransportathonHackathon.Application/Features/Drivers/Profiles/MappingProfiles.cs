using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Carriers.Commands.Create;
using TransportathonHackathon.Application.Features.Carriers.Commands.Delete;
using TransportathonHackathon.Application.Features.Carriers.Commands.Update;
using TransportathonHackathon.Application.Features.Carriers.Queries.GetById;
using TransportathonHackathon.Application.Features.Carriers.Queries.GetList;
using TransportathonHackathon.Application.Features.Drivers.Commands.CreateDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.DeleteDriver;
using TransportathonHackathon.Application.Features.Drivers.Commands.UpdateDriver;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetById;
using TransportathonHackathon.Application.Features.Drivers.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Drivers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Driver, CreateDriverCommand>().ReverseMap();
            CreateMap<Driver, CreatedDriverResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Driver, DeletedDriverResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Driver, UpdateDriverCommand>().ReverseMap();

            CreateMap<Driver, UpdatedDriverResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Driver, GetByIdDriverResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Driver, GetListDriverResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Paginate<Driver>, Paginate<GetListDriverResponse>>();
        }
    }
}
