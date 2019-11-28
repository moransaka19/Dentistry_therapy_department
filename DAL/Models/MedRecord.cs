using System;

namespace DAL.Models
{
	public class MedRecord
	{
		public int MedRecordId { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public DateTime DOB { get; set; }
		public int SickId { get; set; }
	}
}