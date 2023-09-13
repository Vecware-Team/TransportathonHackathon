using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Companies.Commands.Create;
using TransportathonHackathon.Application.Features.Companies.Commands.Delete;
using TransportathonHackathon.Application.Features.Companies.Commands.Update;
using TransportathonHackathon.Application.Features.Companies.Queries.GetByEmail;
using TransportathonHackathon.Application.Features.Companies.Queries.GetById;
using TransportathonHackathon.Application.Features.Companies.Queries.GetList;
using TransportathonHackathon.Application.Features.Companies.Queries.GetListDynamic;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, CreatedCompanyResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
            CreateMap<Company, DeletedCompanyResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Company, UpdateCompanyCommand>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();
            CreateMap<Company, UpdatedCompanyResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Company, GetByIdCompanyResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Company, GetByEmailCompanyResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Company, GetListCompanyResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Paginate<Company>, Paginate<GetListCompanyResponse>>().ReverseMap();

            CreateMap<Company, GetListDynamicCompanyResponse>()
                .ForMember(destinationMember: e => e.Email, memberOptions: opt => opt.MapFrom(e => e.AppUser.Email))
                .ForMember(destinationMember: e => e.UserName, memberOptions: opt => opt.MapFrom(e => e.AppUser.UserName))
                .ReverseMap();

            CreateMap<Paginate<Company>, Paginate<GetListDynamicCompanyResponse>>().ReverseMap();
        }
    }
}
