using BookShopp.Application.Abstract;
using BookShopp.Domain.Entities;
using BookShopp.Domain.Models;

namespace BookShopp.Application.Concrete;

public class CartService : ICartService
{
    public void AddToCart(Cart cart, Book book)
    {
        var cartLine = cart.CartLines.FirstOrDefault(cl => cl.Book?.Id == book.Id);
        if (cartLine != null)
            cartLine.Quantity++;
        else
            cart.CartLines.Add(new CartLine { Quantity = 1, Book = book });
    }
    public void AddToCart(Cart cart, Course course)
    {
        var cartLine = cart.CartLines.FirstOrDefault(cl => cl.Course?.Id == course.Id);
        if (cartLine != null)
            cartLine.Quantity++;
        else
            cart.CartLines.Add(new CartLine { Quantity = 1, Course = course });
    }
    public void RemoveFromCart(Cart cart, int bookId, int courseId)
    {
        var cartLine = cart.CartLines.FirstOrDefault(c => c.Book?.Id == bookId || c.Course?.Id == courseId);
        if (cartLine != null)
        {
            cart.CartLines.Remove(cartLine);
        }
    }
    public List<CartLine> List(Cart cart)
    {
        return cart.CartLines;
    }
}
