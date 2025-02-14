using BookShopp.Application.Abstract;
using BookShopp.DataAccess.Abstract;
using BookShopp.Domain.Entities;

namespace BookShopp.Application.Concrete;

public class UserService(IUserDal userDal) : IUserService
{
    private readonly IUserDal _userDal = userDal;

    public void Add(User user)
    {
        _userDal.Add(user);
    }

    public void Delete(int userId)
    {
        var user = _userDal.Get(p => p.Id == userId);
        _userDal.Delete(user);
    }

    public void Edit(User user)
    {
        _userDal.Edit(user);
    }

    public List<User> GetAll()
    {
        return _userDal.GetList();
    }

    public User GetById(int id)
    {
        return _userDal.Get(p => p.Id == id);
    }

}
