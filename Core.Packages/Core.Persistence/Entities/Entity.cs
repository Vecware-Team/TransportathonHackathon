namespace Core.Persistence.Entities
{
    public class Entity : IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }

    public class Entity<TId> : Entity, IEntity<TId>
    {
        public TId Id { get; set; }
    }
}
