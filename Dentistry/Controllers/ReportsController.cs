using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dentistry.Models;

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
            var procedureTotalPriceViewModels = procedureTotalPrices.Select(x => new ProcedureTotalPriceViewModel
            {
                MedRecord = new MedRecordViewModel
                { 
                    MedRecordId = x.MedRecord.MedRecordId,
                    DOB = x.MedRecord.DOB,
                    FirstName = x.MedRecord.FirstName,
                    SecondName = x.MedRecord.SecondName,
                    SickId = x.MedRecord.SickId
                     
                },
                Price = x.Price,
                Procedure = new ProcedureVIewModel
                {
                    ProcedureId = x.Procedure.ProcedureId,
                    Name = x.Procedure.Name,
                }
            });

            return View(procedureTotalPriceViewModels);
        }
    }
}