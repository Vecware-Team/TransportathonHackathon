using TransportathonHackathon.Domain.Entities;

namespace TransportathonHackathon.Application.Features.Languages.Commands.Update
{
    public class UpdatedLanguageResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }
        public IEnumerable<Translate> Translates { get; set; }
    }
}
