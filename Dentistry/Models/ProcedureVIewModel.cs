using AutoMapper;
using DAL.Models;

namespace Dentistry.Models
{
	[AutoMap(typeof(Procedure))]
	public class ProcedureViewModel
	{
		public int ProcedureId { get; set; }
		public string Name { get; set; }
	}
}