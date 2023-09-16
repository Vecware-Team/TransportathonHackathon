using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Update
{
    public class UpdateTranslateCommand : IRequest<UpdatedTranslateResponse>, ITransactionalRequest
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
