using MediatR;

namespace TransportathonHackathon.Application.Features.TransportRequests.Queries.GetById
{
    public class GetByIdTransportRequestQuery : IRequest<GetByIdTransportRequestResponse>
    {
        public Guid Id { get; set; }
    }
}
