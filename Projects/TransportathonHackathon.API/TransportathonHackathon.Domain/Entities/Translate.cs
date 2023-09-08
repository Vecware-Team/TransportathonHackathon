using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class Translate : Entity
    {
        public Guid LanguageId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Language Language { get; set; }
    }
}
