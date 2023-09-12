using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Trucks.Commands.Create;
using TransportathonHackathon.Application.Features.Trucks.Commands.Delete;
using TransportathonHackathon.Application.Features.Trucks.Commands.Update;
using TransportathonHackathon.Application.Features.Trucks.Queries.GetById;
using TransportathonHackathon.Application.Features.Trucks.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Trucks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Truck, CreateTruckCommand>().ReverseMap();
            CreateMap<Truck, CreatedTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap(); ;

            CreateMap<Truck, DeletedTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap(); ;

            CreateMap<Truck, UpdateTruckCommand>().ReverseMap();
            CreateMap<Truck, UpdatedTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();

            CreateMap<Truck, GetByIdTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();

            CreateMap<Truck, GetListTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.CompanyId))
                .ForMember(destinationMember: e => e.DriverId, memberOptions: opt => opt.MapFrom(e => e.Vehicle.DriverId))
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();
            CreateMap<Paginate<Truck>, Paginate<GetListTruckResponse>>().ReverseMap();
        }
    }
}
