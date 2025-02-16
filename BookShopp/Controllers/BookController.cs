using BookShopp.Application.Abstract;
using BookShopp.Application.Concrete;
using BookShopp.Domain.Entities;
using BookShopp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookShopp.Controllers
{
    public class BookController(IBookService bookService) : Controller
    {
        private readonly IBookService _bookService = bookService;

        public IActionResult Index(int page = 1)
        {
            var books = _bookService.GetAll();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new BookViewModel();
            model.Book = new Book();
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(BookViewModel model)
        {
            _bookService.Add(model.Book);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete()
        {
            var model = new BookViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            var model = new BookViewModel
            {
                Book = book
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(BookViewModel model)
        {
            var bookInDb = _bookService.GetById(model.Book.Id);
            if (bookInDb == null)
            {
                return NotFound();
            }

            bookInDb.Name = model.Book.Name;
            bookInDb.Author = model.Book.Author;
            bookInDb.Genre = model.Book.Genre;
            bookInDb.Pages = model.Book.Pages;
            bookInDb.Price = model.Book.Price;
            bookInDb.Description = model.Book.Description;
            bookInDb.Image = model.Book.Image;
            bookInDb.ReadCount = model.Book.ReadCount;

            _bookService.Edit(bookInDb);
            return RedirectToAction("Index");
        }
    }
}
