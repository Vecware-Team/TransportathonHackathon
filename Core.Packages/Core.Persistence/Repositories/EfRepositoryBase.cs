using Core.Persistence.Dynamic;
using Core.Persistence.Entities;
using Core.Persistence.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public class EfRepositoryBase<TEntity, TContext> : IRepository<TEntity>, IAsyncRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {
        protected TContext Context { get; }

        public EfRepositoryBase(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetAsync(
           Expression<Func<TEntity, bool>> predicate,
           Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
           bool withDeleted = false,
           bool enableTracking = true,
           CancellationToken cancellationToken = default
       )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            return await queryable.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        public async Task<IList<TEntity>> GetListAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                return await orderBy(queryable).ToListAsync(cancellationToken);

            return await queryable.ToListAsync(cancellationToken);
        }


        public async Task<IPaginate<TEntity>> GetListPagedAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                return await orderBy(queryable).ToPaginateAsync(index, size, cancellationToken);

            return await queryable.ToPaginateAsync(index, size, cancellationToken);
        }

        public async Task<IList<TEntity>> GetListByDynamicAsync(
            DynamicQuery dynamicQuery,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<TEntity> queryable = Query().ToDynamic(dynamicQuery);

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await queryable.ToListAsync(cancellationToken);
        }

        public async Task<IPaginate<TEntity>> GetListByDynamicPagedAsync(
            DynamicQuery dynamicQuery,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<TEntity> queryable = Query().ToDynamic(dynamicQuery);

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return await queryable.ToPaginateAsync(index, size, cancellationToken);
        }

        public Task<bool> AnyAsync(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            bool enableTracking = true,
            CancellationToken cancellationToken = default
        )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable.AsNoTracking();

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return queryable.AnyAsync(cancellationToken);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> AddRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                entity.CreatedDate = DateTime.UtcNow;

            await Context.AddRangeAsync(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> UpdateRangeAsync(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                entity.UpdatedDate = DateTime.UtcNow;

            Context.UpdateRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<TEntity> DeleteAsync(TEntity entity, bool permanent = true)
        {
            if (!permanent)
            {
                if (entity.DeletedDate is null)
                {
                    entity.DeletedDate = DateTime.UtcNow;
                    Context.Update(entity);
                    await Context.SaveChangesAsync();
                }

                return entity;
            }

            Context.Remove(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<ICollection<TEntity>> DeleteRangeAsync(ICollection<TEntity> entities, bool permanent = true)
        {
            if (!permanent)
            {
                foreach (TEntity entity in entities)
                    if (entity.DeletedDate is null)
                        entity.DeletedDate = DateTime.UtcNow;

                Context.UpdateRange(entities);
                await Context.SaveChangesAsync();
                return entities;
            }

            Context.RemoveRange(entities);
            await Context.SaveChangesAsync();
            return entities;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public TEntity? Get(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true
        )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            return queryable.FirstOrDefault(predicate);
        }

        public IList<TEntity> GetList(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true
        )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                return orderBy(queryable).ToList();

            return queryable.ToList();
        }

        public IPaginate<TEntity> GetListPaged(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true
        )
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            if (orderBy != null)
                return orderBy(queryable).ToPaginate(index, size);

            return queryable.ToPaginate(index, size);
        }

        public IList<TEntity> GetListByDynamic(
            DynamicQuery dynamicQuery,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true
        )
        {
            IQueryable<TEntity> queryable = Query().ToDynamic(dynamicQuery);

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return queryable.ToList();
        }

        public IPaginate<TEntity> GetListByDynamicPaged(
            DynamicQuery dynamicQuery,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true
        )
        {
            IQueryable<TEntity> queryable = Query().ToDynamic(dynamicQuery);

            if (!enableTracking)
                queryable = queryable.AsNoTracking();

            if (include != null)
                queryable = include(queryable);

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return queryable.ToPaginate(index, size);
        }

        public bool Any(Expression<Func<TEntity, bool>>? predicate = null, bool withDeleted = false, bool enableTracking = true)
        {
            IQueryable<TEntity> queryable = Query();

            if (!enableTracking)
                queryable.AsNoTracking();

            if (withDeleted)
                queryable = queryable.IgnoreQueryFilters();

            if (predicate != null)
                queryable = queryable.Where(predicate);

            return queryable.Any();
        }

        public TEntity Add(TEntity entity)
        {
            entity.CreatedDate = DateTime.UtcNow;
            Context.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public ICollection<TEntity> AddRange(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                entity.CreatedDate = DateTime.UtcNow;

            Context.AddRange(entities);
            Context.SaveChanges();
            return entities;
        }

        public TEntity Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            Context.Update(entity);
            Context.SaveChanges();
            return entity;
        }

        public ICollection<TEntity> UpdateRange(ICollection<TEntity> entities)
        {
            foreach (TEntity entity in entities)
                entity.UpdatedDate = DateTime.UtcNow;

            Context.UpdateRange(entities);
            Context.SaveChanges();
            return entities;
        }

        public TEntity Delete(TEntity entity, bool permanent = true)
        {
            if (!permanent)
            {
                if (entity.DeletedDate is null)
                {
                    entity.DeletedDate = DateTime.UtcNow;
                    Context.Update(entity);
                    Context.SaveChanges();
                }

                return entity;
            }

            Context.Remove(entity);
            Context.SaveChanges();
            return entity;
        }

        public ICollection<TEntity> DeleteRange(ICollection<TEntity> entities, bool permanent = true)
        {
            if (!permanent)
            {
                foreach (TEntity entity in entities)
                    if (entity.DeletedDate is null)
                        entity.DeletedDate = DateTime.UtcNow;

                Context.UpdateRange(entities);
                Context.SaveChanges();
                return entities;
            }

            Context.RemoveRange(entities);
            Context.SaveChanges();
            return entities;
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public IQueryable<TEntity> Query() => Context.Set<TEntity>();
    }
}
