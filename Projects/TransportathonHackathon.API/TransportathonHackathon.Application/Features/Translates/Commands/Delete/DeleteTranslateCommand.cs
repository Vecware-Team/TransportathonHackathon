using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Delete
{
    public class DeleteTranslateCommand : IRequest<DeletedTranslateResponse>, ITransactionalRequest
    {
        public Guid Id { get; set; }
    }
}
