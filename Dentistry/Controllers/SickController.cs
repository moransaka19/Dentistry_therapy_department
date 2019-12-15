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
    public class SickController : Controller
    {
        private readonly ISickRepository _sickRepository;
        private readonly IMapper _mapper;

        public SickController(ISickRepository sickRepository,
            IMapper mapper)
        {
            _sickRepository = sickRepository;
            _mapper = mapper;
        }

        // GET: Sick
        public ActionResult Index()
        {
            var sicks = _mapper.Map<IEnumerable<SickViewModel>>(_sickRepository.GetAll());

            return View(sicks);
        }

        // GET: Sick/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sick/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SickViewModel model)
        {
            try
            {
                _sickRepository.Add(_mapper.Map<Sick>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Sick/Edit/5
        public ActionResult Edit(int id)
        {
            var sick = _mapper.Map<SickViewModel>(_sickRepository.GetById(id));

            return View(sick);
        }

        // POST: Sick/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SickViewModel model)
        {
            try
            {
                model.SickId = id;
                _sickRepository.Update(_mapper.Map<Sick>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}