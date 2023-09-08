using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Customers.Commands.Create;
using TransportathonHackathon.Application.Features.Customers.Commands.Delete;
using TransportathonHackathon.Application.Features.Customers.Commands.Update;
using TransportathonHackathon.Application.Features.Customers.Queries.GetById;
using TransportathonHackathon.Application.Features.Customers.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Customers.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Customer, CreateCustomerCommand>().ReverseMap();
            CreateMap<Customer, CreatedCustomerResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Customer, DeleteCustomerCommand>().ReverseMap();
            CreateMap<Customer, DeletedCustomerResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Customer, UpdateCustomerCommand>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();
            CreateMap<Customer, UpdatedCustomerResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Customer, GetByIdCustomerResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Customer, GetListCustomerResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Paginate<Customer>, Paginate<GetListCustomerResponse>>().ReverseMap();
        }
    }
}
