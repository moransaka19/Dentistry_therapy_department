using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using Dentistry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.Controllers
{
    public class ProcedureController : Controller
    {
		private readonly IMapper _mapper;
		private readonly IProcedureRepository _procedureRepository;

		public ProcedureController(IMapper mapper,
			IProcedureRepository procedureRepository)
		{
			_mapper = mapper;
			_procedureRepository = procedureRepository;
		}

        // GET: Procedure
        public ActionResult Index()
        {
			var procedures = _mapper.Map<IEnumerable<ProcedureViewModel>>(_procedureRepository.GetAll());

            return View(procedures);
        }

        // GET: Procedure/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procedure/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProcedureViewModel model)
        {
            try
            {
				_procedureRepository.Add(_mapper.Map<Procedure>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
				return RedirectToAction(nameof(Index));
			}
        }

        // GET: Procedure/Edit/5
        public ActionResult Edit(int id)
        {
			var procedure = _mapper.Map<ProcedureViewModel>(_procedureRepository.GetAll().FirstOrDefault(x => x.ProcedureId == id));

            return View(procedure);
        }

        // POST: Procedure/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] ProcedureViewModel model)
        {
            try
            {
				model.ProcedureId = id;
				_procedureRepository.Update(_mapper.Map<Procedure>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
				return RedirectToAction(nameof(Index));
			}
        }
    }
}