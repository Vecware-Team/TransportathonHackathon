using AutoMapper;
using TransportathonHackathon.Application.Features.Languages.Commands.Create;
using TransportathonHackathon.Application.Features.Languages.Commands.Delete;
using TransportathonHackathon.Application.Features.Languages.Commands.Update;
using TransportathonHackathon.Application.Features.Languages.Queries.GetByCode;
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

            CreateMap<Language, UpdateLanguageCommand>().ReverseMap();
            CreateMap<Language, UpdatedLanguageResponse>().ReverseMap();

            CreateMap<Language, GetByIdLanguageResponse>().ReverseMap();

            CreateMap<Language, GetByCodeLanguageResponse>().ReverseMap();

            CreateMap<Language, GetListLanguageResponse>().ReverseMap();
        }
    }
}
