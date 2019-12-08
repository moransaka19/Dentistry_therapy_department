using AutoMapper;
using DAL.Models;
using Dentistry.Models;

namespace Dentistry.MapProfiles
{
	public class MedicineProfile : Profile
	{
		public MedicineProfile()
		{
			CreateMap<Medicine, MedicineViewModel>();

			CreateMap<MedicineViewModel, Medicine>();
		}
	}
}
