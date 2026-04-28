using GESTIONES.Data;
using GESTIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace GESTIONES.Controllers;

public class UserController : Controller
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

    // /User
    public IActionResult Index()
    {
        var users = _context.Users.ToList();
        return View("~/Views/user/user.cshtml", users);
    }

    // /User/Users
    public IActionResult Users()
    {
        var users = _context.Users.ToList();
        return View("~/Views/User/User.cshtml", users);
    }

    // /User/Create
    public IActionResult Create()
    {
        return View("~/Views/user/Create.cshtml");
    }

    // /User/Store
    [HttpPost]
    public IActionResult Store(User user)
    {
        if (!ModelState.IsValid)
            return View("~/Views/user/user.cshtml", user);

        user.dateRegistered = DateTime.Now;
        _context.Users.Add(user);
        _context.SaveChanges();

        TempData["message"] = "Usuario creado correctamente.";
        return RedirectToAction("Users");
    }

    // /User/Show/1
    public IActionResult Show(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return View("~/Views/user/Show.cshtml", user);
    }

    // /User/Edit/1
    public IActionResult Edit(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return View("~/Views/user/Edit.cshtml", user);
    }

    // /User/Update
    [HttpPost]
    public IActionResult Update(User user)
    {
        if (!ModelState.IsValid) return View("~/Views/user/Edit.cshtml", user);
        _context.Users.Update(user);
        _context.SaveChanges();
        TempData["message"] = " actualizado correctamente.";
        return RedirectToAction("Index");
    }


    // /User/Destroy
    [HttpPost]
    public IActionResult Destroy(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();

        _context.Users.Remove(user);
        _context.SaveChanges();

        TempData["message"] = "Usuario eliminado correctamente.";
        return RedirectToAction("Users");
    }
}