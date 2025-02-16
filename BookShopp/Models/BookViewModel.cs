using BookShopp.Domain.Entities;

namespace BookShopp.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public int ReadCount { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Price { get; set; }
    }
}
