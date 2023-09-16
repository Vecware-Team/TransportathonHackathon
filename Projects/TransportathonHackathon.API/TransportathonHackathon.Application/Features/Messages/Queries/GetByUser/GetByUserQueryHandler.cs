using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TransportathonHackathon.Application.Repositories;
using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Messages.Queries.GetByUser
{
    public class GetByUserQueryHandler : IRequestHandler<GetByUserQuery, List<GetByUserResponse>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetByUserQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<List<GetByUserResponse>> Handle(GetByUserQuery request, CancellationToken cancellationToken)
        {
            IList<Message> messages = await _messageRepository.GetListAsync(
                e => e.SenderId == request.UserId || e.ReceiverId == request.UserId,
                include: e => e.Include(e => e.Sender).Include(e => e.Receiver),
                orderBy: e => e.OrderByDescending(e => e.SendDate)
            );

            List<GetByUserResponse> response = new();

            messages.ToList().ForEach(e =>
            {
                if (!response.Contains(response.FirstOrDefault(c => c.UserId == e.SenderId || c.UserId == e.ReceiverId)))
                {
                    response.Add(new()
                    {
                        UserId = request.UserId == e.SenderId ? e.ReceiverId : e.SenderId,
                        UserName = request.UserId == e.SenderId ? e.Receiver.UserName : e.Sender.UserName,
                        LastMessage = e.MessageText,
                        SendDate = e.SendDate
                    });
                }
            });

            return response;
        }
    }
}
