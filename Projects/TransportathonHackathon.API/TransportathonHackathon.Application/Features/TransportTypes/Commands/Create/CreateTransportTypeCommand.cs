using MediatR;

namespace TransportathonHackathon.Application.Features.TransportTypes.Commands.Create
{
    public class CreateTransportTypeCommand : IRequest<CreatedTransportTypeResponse>
    {
        public string Type { get; set; }
    }
}
