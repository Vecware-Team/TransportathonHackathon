using Microsoft.EntityFrameworkCore;

namespace Core.Persistence.Pagination
{
    public static class IQueryablePaginateExtensions
    {
        public static async Task<IPaginate<TEntity>> ToPaginateAsync<TEntity>(this IQueryable<TEntity> source, int index, int size, CancellationToken cancellationToken = default)
        {
            int count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            List<TEntity> items = await source.Skip(index * size).Take(size).ToListAsync(cancellationToken).ConfigureAwait(false);

            IPaginate<TEntity> pagedData = new Paginate<TEntity>
            {
                Items = items,
                Count = count,
                Index = index,
                Size = size,
                Pages = (int)Math.Ceiling(count / (double)size)
            };

            return pagedData;
        }

        public static IPaginate<TEntity> ToPaginate<TEntity>(this IQueryable<TEntity> source, int index, int size)
        {
            int count = source.Count();
            List<TEntity> items = source.Skip(index * size).Take(size).ToList();

            IPaginate<TEntity> pagedData = new Paginate<TEntity>
            {
                Items = items,
                Count = count,
                Index = index,
                Size = size,
                Pages = (int)Math.Ceiling(count / (double)size)
            };

            return pagedData;
        }
    }
}
