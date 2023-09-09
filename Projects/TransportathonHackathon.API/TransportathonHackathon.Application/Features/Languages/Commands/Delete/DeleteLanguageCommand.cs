using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Delete
{
    public class DeleteLanguageCommand : IRequest<DeletedLanguageResponse>
    {
        public Guid Id { get; set; }
    }
}
