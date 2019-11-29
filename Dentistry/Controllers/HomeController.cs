using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dentistry.Models;
using DAL.Repositories;
using DAL.Models;

namespace Dentistry.Controllers
{
	public class HomeController : Controller
	{
		private readonly IDoctorRepository _doctorRepository;
		private readonly IJournalRepository _journalRepository;
        private readonly IProcedureRepository _procedureRepository;

        public HomeController(IDoctorRepository doctorRepository, IJournalRepository journalRepository, IProcedureRepository procedureRepository)
		{
			_doctorRepository = doctorRepository;
            _journalRepository = journalRepository;
            _procedureRepository = procedureRepository;
        }

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Create()
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
