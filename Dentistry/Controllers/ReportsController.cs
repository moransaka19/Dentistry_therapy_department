using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repositories;
using Dentistry.Models;
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
            var procedureTotalPrices = _procedureRepository.GetProcedureTotalPrices()
				.Select(x => new ProcedureTotalPriceViewModel() 
						{
							Price = x.Price,
							MedRecord = new MedRecordViewModel() { FirstName = x.MedRecord.FirstName, SecondName = x.MedRecord.SecondName, SickId = x.MedRecord.SickId, MedRecordId = x.MedRecord.MedRecordId, DOB = x.MedRecord.DOB },
							Procedure = new ProcedureViewModel() { Name = x.Procedure.Name, ProcedureId = x.Procedure.ProcedureId }
						});
            
            return View(procedureTotalPrices);
        }
    }
}