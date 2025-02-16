using BookShopp.Domain.Models;

namespace BookShopp.Services
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
