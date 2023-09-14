using MediatR;

namespace TransportathonHackathon.Application.Features.Messages.Queries.GetByUser
{
    public class GetByUserQuery : IRequest<List<GetByUserResponse>>
    {
        public Guid UserId { get; set; }
    }
}
