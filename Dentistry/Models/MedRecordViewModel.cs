using AutoMapper;
using DAL.Models;
using System;

namespace Dentistry.Models
{
	[AutoMap(typeof(MedRecord))]
	public class MedRecordViewModel
    {
		public int MedRecordId { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		public DateTime DOB { get; set; }
		public int SickId { get; set; }
	}
}