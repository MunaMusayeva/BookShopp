using BookShopp.Domain.Entities;

namespace BookShopp.Application.Abstract;

public interface ICourseService
{
    public List<Course> GetAll();
    Course GetById(int id);
    void Add(Course course);
    void Edit(Course course);
    void Delete(int courseId);
}
