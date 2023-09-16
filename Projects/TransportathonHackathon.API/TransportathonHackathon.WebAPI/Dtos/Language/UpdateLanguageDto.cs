namespace TransportathonHackathon.WebAPI.Dtos.Language
{
    public class UpdateLanguageDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }
    }
}
