using BookShopp.Application.Abstract;
using BookShopp.Domain.Entities;
using BookShopp.Domain.Models;

namespace BookShopp.Application.Concrete;

public class CartService : ICartService
{
    public void AddToCart(Cart cart, Book book)
    {
        CartLine cartLine = cart.CartLines.FirstOrDefault(cl => cl.Book.Id == book.Id);
        if (cartLine != null)
            cartLine.Quantity++;
        else
            cart.CartLines.Add(new CartLine { Quantity = 1, Book = book });
    }

    public List<CartLine> List(Cart cart)
    {
        return cart.CartLines;
    }

    public void RemoveFromCart(Cart cart, int bookId)
    {
        cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Book.Id == bookId));
    }
}
