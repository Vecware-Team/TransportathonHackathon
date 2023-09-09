using MediatR;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Update
{
    public class UpdateLanguageCommand : IRequest<UpdatedLanguageResponse>
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }
    }
}
