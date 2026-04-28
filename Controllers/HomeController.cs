using System.Diagnostics;
using GESTIONES.Data;
using GESTIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace GESTIONES.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var users = _context.Loans.ToList();
        return View("~/Views/arrenting/loan.cshtml", users); 
    }



    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public IActionResult User()
    {
        var users = _context.Loans.ToList();
        return View("~/Views/arrenting/loan.cshtml", users); 
    }
}