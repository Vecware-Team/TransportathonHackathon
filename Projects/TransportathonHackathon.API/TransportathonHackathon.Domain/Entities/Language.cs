using Core.Persistence.Entities;

namespace TransportathonHackathon.Domain.Entities
{
    public class Language : Entity<Guid>
    {
        public string Code { get; set; }
        public string GloballyName { get; set; }
        public string LocallyName { get; set; }

        public virtual ICollection<Translate> Translates { get; set; }

    }
}
