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

        private readonly IMedRecordRepository _medRecordRepository;
        private readonly IMapper _mapper;

        public ReportsController(IProcedureRepository procedureRepository,
            IMedRecordRepository medRecordRepository,
            IMapper mapper)
        {
            _procedureRepository = procedureRepository;
            _medRecordRepository = medRecordRepository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            return View();
        }

        //GET: Prices
        public ActionResult Prices()
        {
            var procedureTotalPrices = _procedureRepository.GetProcedureTotalPrices()
                .Select(x => new ProcedureTotalPriceViewModel()
                {
                    Price = x.Price,
                    MedRecord = new MedRecordViewModel() { FirstName = x.MedRecord.FirstName, SecondName = x.MedRecord.SecondName, MedRecordId = x.MedRecord.MedRecordId, DOB = x.MedRecord.DOB },
                    Procedure = new ProcedureViewModel() { Name = x.Procedure.Name, ProcedureId = x.Procedure.ProcedureId }
                });

            return View(procedureTotalPrices);
        }

        //GET: MedRecords
        public ActionResult MedRecords()
        {
            var medRecords = _mapper.Map<IEnumerable<MedRecordViewModel>>(_medRecordRepository.GetAll());
            
            return View(medRecords);
        }

        //GET: Procedures
        public ActionResult Procedures()
        {
            var procedures = _mapper.Map<IEnumerable<ProcedureSumPricesViewModel>>(_procedureRepository.GetProcedureSumPrices());
                

            return View(procedures);
        }
    }
}