using MediatR;

namespace TransportathonHackathon.Application.Features.TransportTypes.Queries.GetById
{
    public class GetByIdTransportTypeQuery : IRequest<GetByIdTransportTypeResponse>
    {
        public Guid Id { get; set; }
    }
}
