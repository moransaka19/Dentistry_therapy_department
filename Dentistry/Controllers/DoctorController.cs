using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Repositories;
using Dentistry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        // GET: Doctor
        public ActionResult Index()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorViewModels = doctors.Select(x => new DoctorViewModel
            {
                DoctorId = x.DoctorId,
                FirstName = x.FirstName,
                SecondName = x.SecondName
            });
            return View(doctorViewModels);
        }

        // GET: Doctor/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Doctor/Create
        public ActionResult Create()
        {
            var doctors = _doctorRepository.GetAll();
            var doctorViewModels = doctors.Select(x => new DoctorViewModel
            {
                DoctorId = x.DoctorId,
                FirstName = x.FirstName,
                SecondName = x.SecondName
            });

            var addDoctorViewModel = new AddDoctorViewModel
            {
                doctors = doctorViewModels
            };

            return View(addDoctorViewModel);
        }

        // POST: Doctor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddDoctorViewModel model)
        {
                // TODO: Add insert logic here
            var doctor = new Doctor
            {
                DoctorId = model.DoctorId
            };

            _doctorRepository.Add(doctor);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Doctor/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Doctor/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("{id}")]
        public ActionResult DeleteDoctor(int id)
        {
            try
            {
                _doctorRepository.Remove(id);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}