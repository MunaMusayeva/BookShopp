using BookShopp.Domain.Entities;
using BookShopp.Domain.Models;

namespace BookShopp.Application.Abstract;

public interface ICartService
{
    void AddToCart(Cart cart, Book book);
    void AddToCart(Cart cart, Course course);
    void RemoveFromCart(Cart cart, int bookId, int courseId);
    List<CartLine> List(Cart cart);
}
