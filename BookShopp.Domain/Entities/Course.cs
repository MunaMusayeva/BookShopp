using BookShopp.Domain.Abstraction;

namespace BookShopp.Domain.Entities;

public class Course:IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mentor { get; set; }
    public string Image { get; set; }
    public int Duration { get; set; }
    public int Price { get; set; }
    public string Required_Skills { get; set; }
}
