using BookShopp.Application.Abstract;
using BookShopp.Models;
using BookShopp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShopp.Controllers
{
    public class CartController(IBookService bookService, ICartSessionService cartSessionService, ICartService cartService) : Controller
    {
        private readonly IBookService _bookService = bookService;
        private readonly ICartSessionService _cartSessionService = cartSessionService;
        private readonly ICartService _cartService = cartService;

        public IActionResult AddToCart(int Id)
        {
            var bookToBeAdded = _bookService.GetById(Id);
            var cart = _cartSessionService.GetCart();

            _cartService.AddToCart(cart, bookToBeAdded);
            _cartSessionService.SetCart(cart);
            TempData["message"] = String.Format("Your book , {0} was added successfully to cart!", bookToBeAdded.Name);
            return RedirectToAction("Index", "Book");
        }

        [HttpGet]
        public IActionResult List()
        {
            var cart = _cartSessionService.GetCart();
            var model = new CartListViewModel()
            {
                Cart = cart
            };
            return View(model);
        }

        public IActionResult Remove(int bookId)
        {
            var cart = _cartSessionService.GetCart();
            _cartService.RemoveFromCart(cart, bookId);
            _cartSessionService.SetCart(cart);
            TempData.Add("message", "Your book deleted succesfully from cart");
            return RedirectToAction("List");
        }
    }
}
