using AutoMapper;
using DAL.Models;
using System.Collections.Generic;

namespace Dentistry.Models
{
	public class ProcedureViewModel
	{
		public int ProcedureId { get; set; }
		public string Name { get; set; }
		public IEnumerable<MedicineViewModel> Medicines { get; set; }

		public IEnumerable<int> MedicineIds { get; set; }
	}
}