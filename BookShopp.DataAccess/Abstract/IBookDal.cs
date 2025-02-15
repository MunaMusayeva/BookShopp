using BookShopp.Domain.Entities;
using BookShopp.Repository.DataAccess;

namespace BookShopp.DataAccess.Abstract;

public interface IBookDal : IEntityRepository<Book>
{
}
