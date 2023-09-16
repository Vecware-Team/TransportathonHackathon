namespace TransportathonHackathon.WebAPI.Dtos.Translate
{
    public class UpdateTranslateDto
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

    }
}
