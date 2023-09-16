using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Transaction;
using MediatR;
using System.Security.Claims;

namespace TransportathonHackathon.Application.Features.Translates.Commands.Update
{
    public class UpdateTranslateCommand : IRequest<UpdatedTranslateResponse>, ITransactionalRequest, ISecuredRequest
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public string[] Roles => new string[] { "Admin" };
        public Claim[] Claims => new Claim[] { };
    }
}
