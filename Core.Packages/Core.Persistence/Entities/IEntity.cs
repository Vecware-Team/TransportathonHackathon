namespace Core.Persistence.Entities
{
    public interface IEntity
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
    public interface IEntity<TId> : IEntity
    {
        public TId Id { get; set; }
    }
}
