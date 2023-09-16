using Core.Application.Pipelines.Transaction;
using MediatR;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Create
{
    public class CreateTransportTypeCommand : IRequest<CreatedTransportTypeResponse>, ITransactionalRequest
    {
        public string Type { get; set; }
    }
}
