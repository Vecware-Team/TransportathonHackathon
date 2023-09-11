using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Carriers.Commands.Create;
using TransportathonHackathon.Application.Features.Carriers.Commands.Delete;
using TransportathonHackathon.Application.Features.Carriers.Commands.Update;
using TransportathonHackathon.Application.Features.Carriers.Queries.GetById;
using TransportathonHackathon.Application.Features.Carriers.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Carriers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Carrier, CreateCarrierCommand>().ReverseMap();
            CreateMap<Carrier, CreatedCarrierResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Carrier, DeletedCarrierResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Carrier, UpdateCarrierCommand>().ReverseMap();

            CreateMap<Carrier, UpdatedCarrierResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Carrier, GetByIdCarrierResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Carrier, GetListCarrierResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.Employee.AppUser.UserName))
                .ForMember(destinationMember: e => e.FirstName, memberOptions: opt => opt.MapFrom(e => e.Employee.FirstName))
                .ForMember(destinationMember: e => e.LastName, memberOptions: opt => opt.MapFrom(e => e.Employee.LastName))
                .ForMember(destinationMember: e => e.IsOnTransitNow, memberOptions: opt => opt.MapFrom(e => e.Employee.IsOnTransitNow))
                .ForMember(destinationMember: e => e.Age, memberOptions: opt => opt.MapFrom(e => e.Employee.Age))
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.AppUserId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Employee.Company.CompanyName))
                .ReverseMap();

            CreateMap<Paginate<Carrier>, Paginate<GetListCarrierResponse>>();
        }
    }
}
