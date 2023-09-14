using Core.Persistence.Pagination;
using MediatR;

namespace TransportathonHackathon.Application.Features.Messages.Queries.GetByReceiverAndSender
{
    public class GetByReceiverAndSenderMessageQuery : IRequest<Paginate<GetByReceiverAndSenderMessageResponse>>
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
    }
}
