namespace TransportathonHackathon.Application.Features.Languages.Commands.Create
{
    public class CreatedLanguageResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }
    }
}
