using BookShopp.Domain.Entities;
using BookShopp.Repository.DataAccess;

namespace BookShopp.DataAccess.Abstract;

public interface ICourseDal : IEntityRepository<Course>
{
}
