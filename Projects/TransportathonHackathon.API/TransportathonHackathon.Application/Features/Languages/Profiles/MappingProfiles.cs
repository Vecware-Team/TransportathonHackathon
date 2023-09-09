using AutoMapper;
using TransportathonHackathon.Application.Features.Languages.Commands.Create;
using TransportathonHackathon.Application.Features.Languages.Commands.Delete;
using TransportathonHackathon.Application.Features.Languages.Queries.GetById;
using TransportathonHackathon.Application.Features.Languages.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Language, CreateLanguageCommand>().ReverseMap();
            CreateMap<Language, CreatedLanguageResponse>().ReverseMap();

            CreateMap<Language, DeletedLanguageResponse>().ReverseMap();

            CreateMap<Language, GetByIdLanguageResponse>().ReverseMap();

            CreateMap<Language, GetListLanguageResponse>().ReverseMap();
        }
    }
}
