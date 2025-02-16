using BookShopp.Application.Abstract;
using BookShopp.Application.Concrete;
using BookShopp.DataAccess.Abstract;
using BookShopp.DataAccess.Context;
using BookShopp.DataAccess.Implementation;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookDal, EFBookDal>();
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseDal, EFCourseDal>();
builder.Services.AddDbContext<BookShopDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyConn"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
