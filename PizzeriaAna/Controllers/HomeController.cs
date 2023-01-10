using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaAna.Database;
using PizzeriaAna.Models;
using System.Diagnostics;

namespace PizzeriaAna.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            using (BlogContext db = new BlogContext())
            {
                List<Pizza> listaDellePizze = db.Pizzas.ToList<Pizza>();
                return View("Index", listaDellePizze);
            }

        }

        public IActionResult Details(int id)
        {
            using (BlogContext db = new BlogContext())
            {
                Pizza pizzaRicercata = db.Pizzas.Where(p=>p.Id == id).FirstOrDefault();

                if (pizzaRicercata != null)
                {
                    return View(pizzaRicercata);
                }

                return NotFound("Il post con l'id cercato non esiste!");
            }

        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pizza formData)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", formData);
            }

            using (BlogContext db = new BlogContext())
            {
                db.Pizzas.Add(formData);
                db.SaveChanges();

            }
            return RedirectToAction("Index");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}