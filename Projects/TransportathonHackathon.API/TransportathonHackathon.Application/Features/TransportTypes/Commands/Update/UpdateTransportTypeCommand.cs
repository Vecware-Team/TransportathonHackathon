using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Update
{
    public class UpdateTransportTypeCommand : IRequest<UpdatedTransportTypeResponse>, ITransactionalRequest
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
    }
}
