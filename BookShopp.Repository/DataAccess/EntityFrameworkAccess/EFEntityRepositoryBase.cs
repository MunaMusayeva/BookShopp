using BookShopp.Domain.Abstraction;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BookShopp.Repository.DataAccess.EntityFrameworkAccess;

public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
{
    private readonly TContext _context;

    public EFEntityRepositoryBase(TContext context)
    {
        _context = context;
    }

    public void Add(TEntity entity)
    {
        var addedEntity = _context.Entry(entity);
        addedEntity.State = EntityState.Added;
        _context.SaveChanges();
    }

    public void Delete(TEntity entity)
    {
        var deletedEntity = _context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        _context.SaveChanges();
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter = null)
    {
        return _context.Set<TEntity>().SingleOrDefault(filter);
    }

    public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
    {
        return filter == null
            ? [.. _context.Set<TEntity>()]
            : [.. _context.Set<TEntity>().Where(filter)];
    }

    public void Edit(TEntity entity)
    {
        var updatedEntity = _context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        _context.SaveChanges();
    }
}
