using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Create
{
    public class CreateLanguageCommand : IRequest<CreatedLanguageResponse>
    {
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }
    }
}
