using BookShopp.Domain.Entities;

namespace BookShopp.Application.Abstract;

public interface IBookService
{
    public List<Book> GetAll();
    Book GetById(int id);
    void Add(Book book);
    void Edit(Book book);
    void Delete(int bookId);
}
