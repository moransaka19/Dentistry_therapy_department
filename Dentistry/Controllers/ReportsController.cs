using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IProcedureRepository _procedureRepository;

        public ReportsController(IProcedureRepository procedureRepository)
        {
            _procedureRepository = procedureRepository;
        }

        // GET: Reports
        public ActionResult Index()
        {
            var procedureTotalPrices = _procedureRepository.GetProcedureTotalPrices();
            

            return View();
        }
    }
}