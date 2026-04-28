using GESTIONES.Data;
using GESTIONES.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



namespace GESTIONES.Controllers
{
    public class LoanController : Controller
    {
        private readonly DataContext _context;

        public LoanController(DataContext context)
        {
            _context = context;
        }

        // LISTADO
        public IActionResult Index()
        {
            var loans = _context.Loans
                .Include(l => l.User)
                .Include(l => l.Deporte)
                .ToList();

            return View("~/Views/arrenting/loan.cshtml", loans);
        }

        // FORM
        public IActionResult Create()
        {
            LoadData();
            return View("~/Views/arrenting/Create.cshtml");
        }

        // GUARDAR
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Store(Loan loan)
        {
            Console.WriteLine($"UserId: {loan.UserId}");
            Console.WriteLine($"BookId: {loan.deporteid}");
            
                
            if (!ModelState.IsValid)
            {
                LoadData();
                return View("~/Views/arrenting/Create.cshtml", loan);
            }

            var Deportes = _context.Deportes.Find(loan.deporteid);

            if (Deportes == null || Deportes.Stock <= 0)
            {
                ModelState.AddModelError("BookId", "No hay stock disponible");
                LoadData();
                return View("~/Views/arrenting/Create.cshtml", loan);
            }

            loan.StartDate = DateTime.Now;
            loan.estado = "Activo";
            
            Deportes.Stock--;

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DETALLE
        public IActionResult Show(int id)
        {
            var loan = _context.Loans
                .Include(l => l.User)
                .Include(l => l.Deporte)
                .FirstOrDefault(l => l.Id == id);

            if (loan == null) return NotFound();

            return View("~/Views/arrenting/Show.cshtml", loan);
        }

        // DEVOLVER
        [HttpPost]
        public IActionResult Return(int id)
        {
            var loan = _context.Loans.Find(id);
            if (loan == null) return NotFound();

            loan.estado = "Devuelto";
            loan.EndDate = DateTime.Now;

            var deporte = _context.Deportes.Find(loan.deporteid);
            if (deporte != null) deporte.Stock++;

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // ELIMINAR
        [HttpPost]
        public IActionResult Destroy(int id)
        {
            var loan = _context.Loans.Find(id);
            if (loan == null) return NotFound();

            _context.Loans.Remove(loan);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        private void LoadData()
        {
            ViewBag.Users = _context.Users.ToList();
            ViewBag.Books = _context.Deportes.ToList();
        }
    }
}