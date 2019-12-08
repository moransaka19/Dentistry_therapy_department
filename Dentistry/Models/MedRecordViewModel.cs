using AutoMapper;
using DAL.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dentistry.Models
{
	public class MedRecordViewModel
	{
		public int MedRecordId { get; set; }
		public string FirstName { get; set; }
		public string SecondName { get; set; }
		[DisplayFormat(DataFormatString = "{0:D}")]
		public DateTime DOB { get; set; }
	}
}