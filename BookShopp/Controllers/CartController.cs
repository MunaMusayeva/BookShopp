using BookShopp.Application.Abstract;
using BookShopp.Domain.Models;
using BookShopp.Models;
using BookShopp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookShopp.Controllers;

public class CartController : Controller
{
    private readonly IBookService _bookService;
    private readonly ICourseService _courseService;
    private readonly ICartSessionService _cartSessionService;
    private readonly ICartService _cartService;

    public CartController(IBookService bookService, ICourseService courseService, ICartSessionService cartSessionService, ICartService cartService)
    {
        _bookService = bookService;
        _courseService = courseService;
        _cartSessionService = cartSessionService;
        _cartService = cartService;
    }
    public IActionResult AddToCart(int id, string type)
    {
        var cart = _cartSessionService.GetCart();

        if (type == "book")
        {
            var bookToBeAdded = _bookService.GetById(id);
            _cartService.AddToCart(cart, bookToBeAdded);
            TempData["message"] = $"Your book '{bookToBeAdded.Name}' was added successfully to the cart!";
        }
        else if (type == "course")
        {
            var courseToBeAdded = _courseService.GetById(id);
            _cartService.AddToCart(cart, courseToBeAdded);
            TempData["message"] = $"Your course '{courseToBeAdded.Name}' was added successfully to the cart!";
        }

        _cartSessionService.SetCart(cart);
        return RedirectToAction("Index", type == "book" ? "Book" : "Course");
    }

    public IActionResult Checkout()
    {
        var cart = _cartSessionService.GetCart();

        if (cart.CartLines.Count == 0)
        {
            TempData["message"] = "Your cart is empty.";
            return RedirectToAction("Index"); 
        }

        var model = new CartListViewModel
        {
            Cart = cart,
            TotalBooks = cart.CartLines.Count(cl => cl.Book != null),
            TotalCourses = cart.CartLines.Count(cl => cl.Course != null),
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Checkout(CartListViewModel model)
    {
        if (ModelState.IsValid)
        {
            TempData["message"] = "Your payment was successful!";
            _cartSessionService.SetCart(new Cart());
            return RedirectToAction("OrderConfirmation");
        }

        return View(model); 
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

    public IActionResult Order()
    {
        return View();
    }
    public IActionResult Remove(int bookId, int courseId)
    {
        var cart = _cartSessionService.GetCart();
        _cartService.RemoveFromCart(cart, bookId, courseId);
        _cartSessionService.SetCart(cart);
        TempData["message"] = "Your item was successfully removed from the cart.";
        return RedirectToAction("List");
    }
}
