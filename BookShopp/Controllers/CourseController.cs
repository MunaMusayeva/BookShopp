using BookShopp.Application.Abstract;
using BookShopp.Application.Concrete;
using BookShopp.Domain.Entities;
using BookShopp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopp.Controllers
{
    public class CourseController(ICourseService courseService) : Controller
    {
        private readonly ICourseService _courseService = courseService;

        public IActionResult Index()
        {
            var courses = _courseService.GetAll();
            return View(courses);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new CourseViewModel();
            model.Course = new Course();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(CourseViewModel model)
        {
            _courseService.Add(model.Course);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            var model = new CourseViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _courseService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var course = _courseService.GetById(id);
            if (course == null)
            {
                return NotFound();
            }

            var model = new CourseViewModel
            {
                Course = course
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CourseViewModel model)
        {
            var courseInDb = _courseService.GetById(model.Course.Id);
            if (courseInDb == null)
            {
                return NotFound();
            }

            courseInDb.Name = model.Course.Name;
            courseInDb.Mentor = model.Course.Mentor;
            courseInDb.Image = model.Course.Image;
            courseInDb.Duration = model.Course.Duration;
            courseInDb.Price = model.Course.Price;
            courseInDb.Required_Skills = model.Course.Required_Skills;

        _courseService.Edit(courseInDb);
            return RedirectToAction("Index");
        }
    }
}
