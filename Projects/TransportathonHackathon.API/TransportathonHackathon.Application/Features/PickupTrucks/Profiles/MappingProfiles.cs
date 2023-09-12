using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Create;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Delete;
using TransportathonHackathon.Application.Features.PickupTrucks.Commands.Update;
using TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetById;
using TransportathonHackathon.Application.Features.PickupTrucks.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.PickupTrucks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<PickupTruck, CreatePickupTruckCommand>();
            CreateMap<PickupTruck, CreatedPickupTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap(); ;

            CreateMap<PickupTruck, DeletedPickupTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap(); ;

            CreateMap<PickupTruck, UpdatePickupTruckCommand>().ReverseMap();
            CreateMap<PickupTruck, UpdatedPickupTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();

            CreateMap<PickupTruck, GetByIdPickupTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();

            CreateMap<PickupTruck, GetListPickupTruckResponse>()
                .ForMember(destinationMember: e => e.CompanyName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Company.CompanyName))
                .ForMember(destinationMember: e => e.DriverName, memberOptions: opt => opt.MapFrom(e => e.Vehicle.Driver.Employee.FirstName))
                .ReverseMap();
            CreateMap<Paginate<PickupTruck>, Paginate<GetListPickupTruckResponse>>().ReverseMap();
        }
    }
}
