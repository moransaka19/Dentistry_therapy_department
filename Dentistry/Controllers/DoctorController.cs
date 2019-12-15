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
    public class DoctorController : Controller
    {
		private readonly IMapper _mapper;
		private readonly IDoctorRepository _doctorRepository;

		public DoctorController(IMapper mapper,
			IDoctorRepository doctorRepository)
		{
			_mapper = mapper;
			_doctorRepository = doctorRepository;
		}

        // GET: Doctor
        public ActionResult Index()
        {
			var doctors = _mapper.Map<IEnumerable<DoctorViewModel>>(_doctorRepository.GetAll());

            return View(doctors);
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DoctorViewModel model)
        {
            try
            {
				_doctorRepository.Add(_mapper.Map<Doctor>(model));

				return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
			var doctor = _mapper.Map<DoctorViewModel>(_doctorRepository.GetById(id));

            return View(doctor);
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] DoctorViewModel model)
        {
            try
            {
				model.DoctorId = id;
				_doctorRepository.Update(_mapper.Map<Doctor>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
				return RedirectToAction(nameof(Index));
			}
        }

        public ActionResult Delete(int id)
        {
            try
            {
				_doctorRepository.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
				return RedirectToAction(nameof(Index));
			}
        }
    }
}