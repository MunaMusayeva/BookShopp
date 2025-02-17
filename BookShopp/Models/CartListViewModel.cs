using BookShopp.Domain.Models;

namespace BookShopp.Models;

public class CartListViewModel
{
    public Cart Cart { get; set; }
    public int TotalBooks { get; set; }
    public int TotalCourses { get; set; }
    public int TotalAmount => Cart.CartLines.Sum(cl => cl.Book != null ? cl.Book.Price * cl.Quantity : 0) +
                             Cart.CartLines.Sum(cl => cl.Course != null ? cl.Course.Price * cl.Quantity : 0);
}


