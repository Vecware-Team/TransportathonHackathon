using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Companies.Commands.Create;
using TransportathonHackathon.Application.Features.Companies.Commands.Delete;
using TransportathonHackathon.Application.Features.Companies.Commands.Update;
using TransportathonHackathon.Application.Features.Companies.Queries.GetByEmail;
using TransportathonHackathon.Application.Features.Companies.Queries.GetById;
using TransportathonHackathon.Application.Features.Companies.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Companies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Company, CreateCompanyCommand>().ReverseMap();
            CreateMap<Company, CreatedCompanyResponse>().ReverseMap();

            CreateMap<Company, DeleteCompanyCommand>().ReverseMap();
            CreateMap<Company, DeletedCompanyResponse>().ReverseMap();

            CreateMap<Company, UpdateCompanyCommand>().ReverseMap();
            CreateMap<Company, UpdatedCompanyResponse>().ReverseMap();

            CreateMap<Company, GetByIdCompanyResponse>().ReverseMap();

            CreateMap<Company, GetByEmailCompanyResponse>().ReverseMap();

            CreateMap<Company, GetListCompanyResponse>().ReverseMap();
            CreateMap<IPaginate<Company>, IPaginate<GetListCompanyResponse>>().ReverseMap();
        }
    }
}
