using BookShopp.Domain.Entities;

namespace BookShopp.Application.Abstract;

public interface IUserService
{
    public List<User> GetAll();
    User GetById(int id);
    void Add(User user);
    void Edit(User user);
    void Delete(int userId);
}
