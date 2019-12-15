using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Models;
using DAL.Repositories;
using Dentistry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dentistry.Controllers
{
    public class MedRecordController : Controller
    {
        private readonly IMedRecordRepository _medRecordRepository;
        private readonly IMapper _mapper;

        public MedRecordController(IMedRecordRepository medRecordRepository,
            IMapper mapper)
        {
            _medRecordRepository = medRecordRepository;
            _mapper = mapper;
        }

        // GET: MedRecord
        public ActionResult Index([FromQuery] OrderDirection order)
        {
            var medRecords = _mapper.Map<IEnumerable<MedRecordViewModel>>(_medRecordRepository.GetAll(x => x.DOB, order));

            return View(medRecords);
        }

        // GET: MedRecord/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MedRecord/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MedRecordViewModel model)
        {
            try
            {
                _medRecordRepository.Add(_mapper.Map<MedRecord>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: MedRecord/Edit/5
        public ActionResult Edit(int id)
        {
            var medRecord = _mapper.Map<MedRecordViewModel>(_medRecordRepository.GetById(id));

            return View(medRecord);
        }

        // POST: MedRecord/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MedRecordViewModel model)
        {
            try
            {
                model.MedRecordId = id;
                _medRecordRepository.Update(_mapper.Map<MedRecord>(model));

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: MedRecord/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MedRecord/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}