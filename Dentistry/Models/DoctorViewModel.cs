using AutoMapper;
using DAL.Models;

namespace Dentistry.Models
{
	[AutoMap(typeof(Doctor))]
	public class DoctorViewModel
	{
		public int DoctorId { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
	}
}