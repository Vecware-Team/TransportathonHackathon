using MediatR;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Delete
{
    public class DeleteTranslateCommand : IRequest<DeletedTranslateResponse>
    {
        public Guid Id { get; set; }
    }
}
