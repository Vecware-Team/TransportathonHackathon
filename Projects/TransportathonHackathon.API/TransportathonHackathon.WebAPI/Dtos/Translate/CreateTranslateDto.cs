namespace TransportathonHackathon.WebAPI.Dtos.Translate
{
    public class CreateTranslateDto
    {
        public Guid LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
