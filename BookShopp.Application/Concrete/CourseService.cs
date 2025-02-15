using BookShopp.Application.Abstract;
using BookShopp.DataAccess.Abstract;
using BookShopp.DataAccess.Implementation;
using BookShopp.Domain.Entities;

namespace BookShopp.Application.Concrete;

public class CourseService(ICourseDal courseDal) : ICourseService
{
    private readonly ICourseDal _courseDal = courseDal;

    public void Add(Course course)
    {
        _courseDal.Add(course);
    }

    public void Delete(int courseId)
    {
        var course = _courseDal.Get(p => p.Id == courseId);
        _courseDal.Delete(course);
    }

    public void Edit(Course course)
    {
        _courseDal.Edit(course);
    }

    public List<Course> GetAll()
    {
        return _courseDal.GetList();
    }

    public Course GetById(int id)
    {
        return _courseDal.Get(p => p.Id == id);
    }
}
