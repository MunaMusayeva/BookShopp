using BookShopp.Application.Abstract;
using BookShopp.Application.Concrete;
using BookShopp.DataAccess.Abstract;
using BookShopp.DataAccess.Context;
using BookShopp.DataAccess.Implementation;
using BookShopp.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddSingleton<ICartSessionService, CartSessionService>();

builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IBookDal, EFBookDal>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<ICourseDal, EFCourseDal>();
builder.Services.AddScoped<ICourseService, CourseService>();

builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddDbContext<BookShopDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Myconn"));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

var staticFiles = app.UseStaticFiles();
app.MapControllers();
app.MapFallbackToFile("/index.html");

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();