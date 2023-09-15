using Core.Application.Requests;
using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Messages.Queries.GetByReceiverAndSender
{
    public class GetByReceiverAndSenderMessageQuery : IRequest<Paginate<GetByReceiverAndSenderMessageResponse>>
    {
        public PageRequest PageRequest { get; set; } = new(20, 0);
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
