using AutoMapper;
using TransportathonHackathon.Application.Features.Comments.Commands.Create;
using TransportathonHackathon.Application.Features.Comments.Commands.Delete;
using TransportathonHackathon.Application.Features.Comments.Commands.Update;
using TransportathonHackathon.Application.Features.Comments.Queries.GetById;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Comments.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Comment, CreateCommentCommand>().ReverseMap();
            CreateMap<Comment, CreatedCommentResponse>().ReverseMap();

            CreateMap<Comment, DeletedCommentResponse>().ReverseMap();

            CreateMap<Comment, UpdateCommentCommand>().ReverseMap();
            CreateMap<Comment, UpdatedCommentResponse>().ReverseMap();

            CreateMap<Comment, GetByIdCommentResponse>().ReverseMap();
        }
    }
}
