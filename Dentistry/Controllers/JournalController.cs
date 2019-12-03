using AutoMapper;
using DAL.Models;
using DAL.Repositories;
using Dentistry.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Dentistry.Controllers
{
    public class JournalController : Controller
    {
        private readonly IJournalRepository _journalRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IProcedureRepository _procedureRepository;
        private readonly IMedRecordRepository _medRecordRepository;
		private readonly IMapper _mapper;

		public JournalController(IJournalRepository journalRepository,
                                 IDoctorRepository doctorRepository,
                                 IProcedureRepository procedureRepository,
                                 IMedRecordRepository medRecordRepository,
								 IMapper mapper)
        {
            _journalRepository = journalRepository;
            _doctorRepository = doctorRepository;
            _procedureRepository = procedureRepository;
            _medRecordRepository = medRecordRepository;
			_mapper = mapper;
		}

        // GET: Journal
        public ActionResult Index()
        {
            var journals = _journalRepository.GetJournals();
            var journalViewmodels = journals.Select(x => new JournalViewModel
            {
				JournalId = x.JournalId,
                CreatedOn = x.CreatedOn,
                Doctor = new DoctorViewModel
                {
                    DoctorId = x.Doctor.DoctorId,
                    FirstName = x.Doctor.FirstName,
                    SecondName = x.Doctor.SecondName
                },
                Procedure = new ProcedureViewModel
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
            var procedures = _procedureRepository.GetAll().Select(x => new ProcedureViewModel
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
			var journal = _mapper.Map<JournalViewModel>(_journalRepository.GetJournals().Where(x => x.JournalId == id).FirstOrDefault());

			journal.Doctors = _mapper.Map<IEnumerable<DoctorViewModel>>(_doctorRepository.GetAll());
			journal.Procedures = _mapper.Map<IEnumerable<ProcedureViewModel>>(_procedureRepository.GetAll());
			journal.MedRecords = _mapper.Map<IEnumerable<MedRecordViewModel>>(_medRecordRepository.GetAll());

			return View(journal);
        }

        // POST: Journal/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {

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