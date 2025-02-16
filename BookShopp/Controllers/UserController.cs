using Microsoft.AspNetCore.Mvc;
using BookShopp.Application.Abstract;
using BookShopp.Domain.Entities;
using BookShopp.Models;

namespace BookShopp.Controllers;

public class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;

    public IActionResult Index()
    {
        var users = _userService.GetAll();
        return View(users);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var model = new UserViewModel();
        model.User = new User();
        return View(model);
    }

    [HttpPost]
    public IActionResult Add(UserViewModel model)
    {
        _userService.Add(model.User);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete()
    {
        var model = new UserViewModel();
        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return RedirectToAction("Index");
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var user = _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }

        var model = new UserViewModel
        {
            User = user
        };

        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(UserViewModel model)
    {
        var userInDb = _userService.GetById(model.User.Id);
        if (userInDb == null)
        {
            return NotFound();
        }

        userInDb.Name = model.User.Name;
        userInDb.Surname = model.User.Surname;
        userInDb.Age = model.User.Age;
        userInDb.Gmail = model.User.Gmail;
        userInDb.Picture = model.User.Picture;

        _userService.Edit(userInDb);
        return RedirectToAction("Index");
    }
}
