using BookShopp.Domain.Entities;
using BookShopp.Domain.Models;

namespace BookShopp.Application.Abstract;

public interface ICartService
{
    void AddToCart(Cart cart, Book book);
    void RemoveFromCart(Cart cart, int bookId);
    List<CartLine> List(Cart cart);
}
