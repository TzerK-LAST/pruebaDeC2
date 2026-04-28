using GESTIONES.Data;
using GESTIONES.Models;
using Microsoft.AspNetCore.Mvc;

namespace GESTIONES.Controllers;

public class deportesController : Controller
{
    private readonly DataContext _context;
    private deporte deporte;

    public deportesController(DataContext context)
    {
        _context = context;
    }

    // /Book — inicio sin botones
    public IActionResult Index()
    {
        var deporte = _context.Deportes.ToList();
        return View("~/Views/deportes/deportes.cshtml", deporte);
    }
    
    // /Book/Create — formulario crear
    public IActionResult CreaResult()
    {
        return View("~/Views/deportes/create.cshtml");
    }

    // /Book/Show/1 — ver detalle
    public IActionResult Show(int id)
    {
        var book = _context.Deportes.Find(id);
        if (book == null) return NotFound();
        return View("~/Views/deportes/Show.cshtml", book);
    }

    // /Book/Create — formulario crear

    // /Book/Store — guardar nuevo
    [HttpPost]
    public IActionResult Store(User Deportes)
    {
        if (!ModelState.IsValid) return View("~/Views/deportes/create.cshtml", Deportes);

        _context.Deportes.Add(deporte);
        _context.SaveChanges();

        TempData["message"] = "Libro creado correctamente.";
        return RedirectToAction("Index");
    }

    // /Book/Edit/1 — formulario editar
    public IActionResult Edit(int id)
    {
        var book = _context.Deportes.Find(id);
        if (book == null) return NotFound();
        return View("~/Views/deportes/Edit.cshtml", book);
    }

    // /Book/Update — guardar cambios
    [HttpPost]
    public IActionResult Update(deporte Deportes)
    {
        if (!ModelState.IsValid) return View("~/Views/deportes/Edit.cshtml", Deportes);

        _context.Deportes.Update(deporte);
        _context.SaveChanges();
        if(!ModelState.IsValid) return View("~/Views/deportes/create.cshtml", Deportes);

        TempData["message"] = "Libro actualizado correctamente.";
        return RedirectToAction("Index");
    }

    // /Book/Destroy — eliminar
    [HttpPost]
    public IActionResult Destroy(int id)
    {
        var deport = _context.Deportes.Find(id);
        if (deport == null) return NotFound();

        _context.Deportes.Remove(deport);
        _context.SaveChanges();

        TempData["message"] = "Libro eliminado correctamente.";
        return RedirectToAction("Index");
    }
}