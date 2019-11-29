using System;

namespace Dentistry.Models
{
	public class MedRecordViewModel
    {
		public int MedRecordId { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public DateTime DOB { get; set; }
		public int SickId { get; set; }
	}
}