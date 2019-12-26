namespace DAL.Models
{
	public class ProcedureMedicine
	{
		public int MedicineId { get; set; }
		public int ProcedureId { get; set; }
		public int Count { get; set; }

		public override bool Equals(object obj) => GetHashCode() == obj.GetHashCode();

		public override int GetHashCode() => $"{MedicineId}:{ProcedureId}".GetHashCode();
	}
}