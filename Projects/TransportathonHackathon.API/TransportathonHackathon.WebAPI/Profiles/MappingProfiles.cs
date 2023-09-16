using AutoMapper;
using TransportathonHackathon.Application.Features.Languages.Commands.Create;
using TransportathonHackathon.Application.Features.Languages.Commands.Delete;
using TransportathonHackathon.Application.Features.Languages.Commands.Update;
using TransportathonHackathon.WebAPI.Dtos.Language;

namespace TransportathonHackathon.WebAPI.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateLanguageDto, CreateLanguageCommand>();
            CreateMap<DeleteLanguageDto, DeleteLanguageCommand>();
            CreateMap<UpdateLanguageDto, UpdateLanguageCommand>();
        }
    }
}
