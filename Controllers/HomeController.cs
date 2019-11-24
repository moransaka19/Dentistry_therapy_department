using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Dentistry_therapy_department.Models;

namespace Dentistry_therapy_department.Controllers
{
    public class HomeController : Controller
    {
        private JournalContext db;

        public HomeController(JournalContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Journal.ToListAsync());
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
