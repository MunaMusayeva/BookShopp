using Microsoft.AspNetCore.Mvc;
using BookShopp.Application.Abstract;
using BookShopp.Domain.Entities;
using BookShopp.Models;

namespace BookShopp.Controllers;

public class UserController(IUserService userService) : Controller
{
    private readonly IUserService _userService = userService;

    public IActionResult Index(int page = 1)
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

    public IActionResult Edit(int id)
    {
        var user = _userService.GetById(id);
        if (user == null) return NotFound();
        return View(user);
    }

    [HttpPost]
    public IActionResult Edit(User user)
    {
        if (ModelState.IsValid)
        {
            _userService.Edit(user);
            return RedirectToAction("Index");
        }
        return View(user);
    }
}
