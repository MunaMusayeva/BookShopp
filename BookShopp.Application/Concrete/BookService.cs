using BookShopp.Application.Abstract;
using BookShopp.DataAccess.Abstract;
using BookShopp.DataAccess.Implementation;
using BookShopp.Domain.Entities;

namespace BookShopp.Application.Concrete;

public class BookService(IBookDal bookDal) : IBookService
{
    private readonly IBookDal _bookDal = bookDal;

    public void Add(Book book)
    {
        _bookDal.Add(book);
    }

    public void Delete(int bookId)
    {
        var book = _bookDal.Get(p => p.Id == bookId);
        _bookDal.Delete(book);
    }

    public void Edit(Book book)
    {
        _bookDal.Edit(book);
    }

    public List<Book> GetAll()
    {
        return _bookDal.GetList();
    }

    public Book GetById(int id)
    {
        return _bookDal.Get(p => p.Id == id);
    }
}
