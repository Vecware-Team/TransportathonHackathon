using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Cars.Commands.Create;
using TransportathonHackathon.Application.Features.Cars.Commands.Delete;
using TransportathonHackathon.Application.Features.Cars.Commands.Update;
using TransportathonHackathon.Application.Features.Cars.Queries.GetById;
using TransportathonHackathon.Application.Features.Cars.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Cars.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Car, CreateCarCommand>().ReverseMap();
            CreateMap<Car, CreatedCarResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap(); ;

            CreateMap<Car, DeletedCarResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap(); ;

            CreateMap<Car, UpdateCarCommand>().ReverseMap();
            CreateMap<Car, UpdatedCarResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();

            CreateMap<Car, GetByIdCarResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();

            CreateMap<Car, GetListCarResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();
            CreateMap<Paginate<Car>, Paginate<GetListCarResponse>>().ReverseMap();
        }
    }
}
