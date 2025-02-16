using BookShopp.Application.Abstract;
using BookShopp.Models;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Microsoft.AspNetCore.Mvc;

namespace BookShopp.ViewComponents
{
    public class BookListViewComponent(IBookService bookService) : ViewComponent
    {
        private readonly IBookService _bookService = bookService;

        public ViewViewComponentResult Invoke()
        {
            var model = new BookListViewModel
            {
                Books = _bookService.GetAll()
            };
            return View(model);
        }
    }
}
