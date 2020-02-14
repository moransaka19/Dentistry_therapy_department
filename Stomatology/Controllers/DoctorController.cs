using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Repositories.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DAL.Repositories;
using Stomatology.Models;

namespace Stomatology.Controllers
{
    [Route("/api/doctors")]
    public class DoctorController : Controller
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorController(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        [HttpGet]
        public IEnumerable<DoctorViewModel> GetAll()
        {
            var doctors =_doctorRepository.GetAll();

            var doctorViewModels = doctors.Select(x => new DoctorViewModel
            {
                FirstName = x.FirstName,
                SecondName = x.SecondName
            });

            return doctorViewModels;
        }
    }
}