using AutoMapper;
using Core.Persistence.Pagination;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Messages.Queries.GetByReceiverAndSender
{
    public class GetByReceiverAndSenderMessageQueryHandler : IRequestHandler<GetByReceiverAndSenderMessageQuery, Paginate<GetByReceiverAndSenderMessageResponse>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetByReceiverAndSenderMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<GetByReceiverAndSenderMessageResponse>> Handle(GetByReceiverAndSenderMessageQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Message> messages = await _messageRepository.GetListPagedAsync(
                e => (e.ReceiverId == request.ReceiverId && e.SenderId == request.SenderId) || (e.ReceiverId == request.SenderId && e.SenderId == request.ReceiverId) ,
                include: e => e.Include(e => e.Receiver).Include(e => e.Sender),
                orderBy: e => e.OrderByDescending(e => e.SendDate),
                index: request.PageRequest.Index,
                size: request.PageRequest.Size
            );

            Paginate<GetByReceiverAndSenderMessageResponse> response = _mapper.Map<Paginate<GetByReceiverAndSenderMessageResponse>>(messages);
            return response;
        }
    }
}
