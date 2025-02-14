using BookShopp.Domain.Abstraction;
using System.Linq.Expressions;
using System.Security.Principal;

namespace BookShopp.Repository.DataAccess;
public interface IEntityRepository<T> where T : class, IEntity, new()
{
    T Get(Expression<Func<T, bool>> filter = null);
    List<T> GetList(Expression<Func<T, bool>> filter = null);
    void Add(T entity);
    void Edit(T entity);
    void Delete(T entity);
}
