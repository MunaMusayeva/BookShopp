namespace BookShopp.Domain.Models;

public class Cart
{
    public List<CartLine> CartLines { get; set; }

    public Cart()
    {
        CartLines = [];
    }

    public int Total
    {
        get
        {
            return CartLines.Sum(c => (c.Book?.Price ?? 0) * c.Quantity);
        }
    }
}
