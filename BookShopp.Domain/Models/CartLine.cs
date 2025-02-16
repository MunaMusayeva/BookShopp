using BookShopp.Domain.Entities;

namespace BookShopp.Domain.Models;

public class CartLine
{
    public Book Book { get; set; }
    public Course Course { get; set; }
    public int Quantity { get; set; }
}
