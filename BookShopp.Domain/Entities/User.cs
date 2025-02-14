using BookShopp.Domain.Abstraction;

namespace BookShopp.Domain.Entities;

public class User : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public int Age { get; set; }
    public string Gmail { get; set; }
    public string Picture { get; set; }
}
