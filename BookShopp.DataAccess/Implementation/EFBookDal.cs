using BookShopp.DataAccess.Abstract;
using BookShopp.DataAccess.Context;
using BookShopp.Domain.Entities;
using BookShopp.Repository.DataAccess.EntityFrameworkAccess;

namespace BookShopp.DataAccess.Implementation;

public class EFBookDal(BookShopDBContext bookShopDBContext) : EFEntityRepositoryBase<Book, BookShopDBContext>(bookShopDBContext), IBookDal
{
}
