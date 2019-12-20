using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dentistry.Models
{
	public class ProcedureViewModel
	{
		private decimal _sumPrices;

		public int ProcedureId { get; set; }
		public string Name { get; set; }
		public IEnumerable<MedicineViewModel> Medicines { get; set; }

		public IEnumerable<int> MedicineIds { get; set; }
		public decimal SumPrises {
			get
			{
				return Math.Round(_sumPrices);
			}
			set
			{
				_sumPrices = Medicines.Sum(x => x.Price);
			}
		}
	}
}