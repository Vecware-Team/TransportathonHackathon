using AutoMapper;
using Core.Persistence.Pagination;
using TransportathonHackathon.Application.Features.Messages.Queries.GetByReceiverAndSender;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Messages.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Message, GetByReceiverAndSenderMessageResponse>().ReverseMap();
            CreateMap<Paginate<Message>, Paginate<GetByReceiverAndSenderMessageResponse>>().ReverseMap();
        }
    }
}
