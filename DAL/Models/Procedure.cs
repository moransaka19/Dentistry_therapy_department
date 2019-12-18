using System.Collections.Generic;

namespace DAL.Models
{
	public class Procedure
	{
		public int ProcedureId { get; set; }
		public string Name { get; set; }

		public ICollection<Medicine> Medicines { get; set; }
	}
}