using DAL.Models;
using DAL.Repositories;
using Dentistry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Dentistry.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IMedRecordRepository _medRecordRepository;

        public JournalController(IJournalRepository journalRepository,
                                 IDoctorRepository doctorRepository,
                                 IProcedureRepository procedureRepository,
                                 IMedRecordRepository medRecordRepository)
        {
            _journalRepository = journalRepository;
            _doctorRepository = doctorRepository;
            _procedureRepository = procedureRepository;
            _medRecordRepository = medRecordRepository;
        }

        // GET: Journal
        public ActionResult Index()
        {
            var journals = _journalRepository.GetJournals();
            var journalViewmodels = journals.Select(x => new JournalViewModel
            {
                CreatedOn = x.CreatedOn,
                Doctor = new DoctorViewModel
                {
                    DoctorId = x.Doctor.DoctorId,
                    FirstName = x.Doctor.FirstName,
                    SecondName = x.Doctor.SecondName
                },
                Procedure = new ProcedureVIewModel
                {
                    ProcedureId = x.Procedure.ProcedureId,
                    Name = x.Procedure.Name
                },
                MedRecord = new MedRecordViewModel
                {
                    MedRecordId = x.MedRecord.MedRecordId,
                    DOB = x.MedRecord.DOB,
                    FirstName = x.MedRecord.FirstName,
                    SecondName = x.MedRecord.SecondName,
                    SickId = x.MedRecord.SickId
                },
            });

            return View(journalViewmodels);
        }

        // GET: Journal/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Journal/Create
        public ActionResult Create()
        {
            var doctors = _doctorRepository.GetAll().Select(x => new DoctorViewModel
            {
                DoctorId = x.DoctorId,
                FirstName = x.FirstName,
                SecondName = x.SecondName
            });
            var medRecord = _medRecordRepository.GetAll().Select(x => new MedRecordViewModel
            {
                MedRecordId = x.MedRecordId,
                DOB = x.DOB,
                FirstName = x.FirstName,
                SecondName = x.SecondName,
                SickId = x.SickId
            });
            var procedures = _procedureRepository.GetAll().Select(x => new ProcedureVIewModel
            {
                ProcedureId = x.ProcedureId,
                Name = x.Name
            });

            var addJournalViewModel = new AddJournalViewModel
            {
                Doctors = doctors,
                MedRecords = medRecord,
                Procedures = procedures
            };

            return View(addJournalViewModel);
        }

        // POST: Journal/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddJournalViewModel model)
        {
            var journal = new Journal
            {
                DoctorId = model.DoctorId,
                ProcedureId = model.ProcedureId,
                MedRecordId = model.MedRecordId
            };

            _journalRepository.Add(journal);

            return RedirectToAction(nameof(Index));
        }

        // GET: Journal/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Journal/Edit/5
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

        // GET: Journal/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Journal/Delete/5
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