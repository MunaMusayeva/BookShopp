using BookShopp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BookShopp.DataAccess.Context;

public class BookShopDBContext:DbContext
{
    public DbSet<User> Users { get; set; }
    //public DbSet<Book> Books { get; set; }
    //public DbSet<Course> Courses { get; set; }

    public BookShopDBContext()
    {

    }

    public BookShopDBContext(DbContextOptions<BookShopDBContext> options) : base(options)
    {

    }
}
