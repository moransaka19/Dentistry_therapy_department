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
    public class MedicineController : Controller
    {
		private readonly IMedicineRepository _medicineRepository;
		private readonly IMapper _mapper;

		public MedicineController(IMedicineRepository medicineRepository,
			IMapper mapper)
		{
			_medicineRepository = medicineRepository;
			_mapper = mapper;
		}

        // GET: Medicine
        public ActionResult Index()
        {
			var medicines = _mapper.Map<IEnumerable<MedicineViewModel>>(_medicineRepository.GetAll());

            return View(medicines);
        }

        // GET: Medicine/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicine/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] MedicineViewModel model)
        {
            try
            {
				_medicineRepository.Add(_mapper.Map<Medicine>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
			{
				return RedirectToAction(nameof(Index));
			}
        }

        // GET: Medicine/Edit/5
        public ActionResult Edit(int id)
        {
            var medicine = _mapper.Map<MedicineViewModel>(_medicineRepository.GetById(id));

            return View(medicine);
        }

        // POST: Medicine/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedicineViewModel model)
        {
            try
            {
                model.MedicineId = id;
                _medicineRepository.Update(_mapper.Map<Medicine>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}