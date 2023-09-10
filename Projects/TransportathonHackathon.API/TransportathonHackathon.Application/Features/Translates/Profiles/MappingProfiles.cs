using AutoMapper;
using TransportathonHackathon.Application.Features.Translates.Commands.Create;
using TransportathonHackathon.Application.Features.Translates.Commands.Delete;
using TransportathonHackathon.Application.Features.Translates.Commands.Update;
using TransportathonHackathon.Application.Features.Translates.Queries.GetById;
using TransportathonHackathon.Application.Features.Translates.Queries.GetByKey;
using TransportathonHackathon.Application.Features.Translates.Queries.GetByLanguageCode;
using TransportathonHackathon.Application.Features.Translates.Queries.GetList;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Translates.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Translate, CreateTranslateCommand>().ReverseMap();
            CreateMap<Translate, CreatedTranslateResponse>().ReverseMap();

            CreateMap<Translate, DeletedTranslateResponse>().ReverseMap();

            CreateMap<Translate, UpdatedTranslateResponse>().ReverseMap();

            CreateMap<Translate, GetByIdTranslateResponse>().ReverseMap();
            
            CreateMap<Translate, GetByKeyTranslateResponse>().ReverseMap();

            CreateMap<Translate, GetByLanguageCodeTranslateResponse>().ReverseMap();

            CreateMap<Translate, GetListTranslateResponse>().ReverseMap();
        }
    }
}
