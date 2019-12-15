using AutoMapper;
using DAL.Models;
using Dentistry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry.MapProfiles
{
	public class DoctorProfile : Profile
	{
		public DoctorProfile()
		{
			CreateMap<Doctor, DoctorViewModel>();

			CreateMap<DoctorViewModel, Doctor>();
		}
	}
}
