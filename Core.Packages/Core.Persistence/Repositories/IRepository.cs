using Core.Persistence.Dynamic;
using Core.Persistence.Entities;
using Core.Persistence.Pagination;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.Persistence.Repositories
{
    public interface IRepository<TEntity> where TEntity : class, IEntity, new()
    {
        TEntity? Get(
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true
        );

        IList<TEntity> GetList(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true
        );

        IPaginate<TEntity> GetListPaged(
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true
        );

        IList<TEntity> GetListByDynamic(
            DynamicQuery dynamicQuery,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            bool withDeleted = false,
            bool enableTracking = true
        );

        IPaginate<TEntity> GetListByDynamicPaged(
            DynamicQuery dynamicQuery,
            Expression<Func<TEntity, bool>>? predicate = null,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>>? include = null,
            int index = 0,
            int size = 10,
            bool withDeleted = false,
            bool enableTracking = true
        );

        bool Any(
            Expression<Func<TEntity, bool>>? predicate = null,
            bool withDeleted = false,
            bool enableTracking = true
        );

        TEntity Add(TEntity entity);

        ICollection<TEntity> AddRange(ICollection<TEntity> entities);

        TEntity Update(TEntity entity);

        ICollection<TEntity> UpdateRange(ICollection<TEntity> entities);

        TEntity Delete(TEntity entity, bool permanent = true);

        ICollection<TEntity> DeleteRange(ICollection<TEntity> entities, bool permanent = true);
        int SaveChanges();
    }
}
