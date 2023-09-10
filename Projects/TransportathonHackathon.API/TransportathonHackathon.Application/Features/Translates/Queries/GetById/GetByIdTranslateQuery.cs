using MediatR;

namespace TransportathonHackathon.Application.Features.Translates.Queries.GetById
{
    public class GetByIdTranslateQuery : IRequest<GetByIdTranslateResponse>
    {
        public Guid Id { get; set; }
    }
}
