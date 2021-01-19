using Microsoft.AspNetCore.Mvc;
using System.Linq;
using MyWebSite.Models;
using System.IO;
using MyWebSite.Data;
using MyWebSite.Models.CompanyViewModels;

namespace MyWebSite.Models
{
    public class HomeController : UserController
    {
        ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Settings.ToList());
        }

        [HttpPost]
        public IActionResult Create(PersonViewModel pvm)
        {
            Settings settings = new Settings { Topic = pvm.Topic };
            Settings setting = new Settings { Language = pvm.Language };

            _context.Settings.Add(settings);
            _context.Settings.Add(setting);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
