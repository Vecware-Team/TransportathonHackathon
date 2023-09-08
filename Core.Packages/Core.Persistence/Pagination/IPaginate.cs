namespace Core.Persistence.Pagination
{
    public interface IPaginate<TEntity>
    {
        int Size { get; }
        int Index { get; }
        int Count { get; }
        int Pages { get; }
        IList<TEntity> Items { get; }
        bool HasPrevious { get; }
        bool HasNext { get; }
    }
}
