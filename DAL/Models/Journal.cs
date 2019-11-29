using System;

namespace DAL.Models
{
	public class Journal
	{
		public int JournalId { get; set; }
		public DateTime Date { get; set; }
		public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public int ProcedureId { get; set; }
        public Procedure Procedure { get; set; }
        public int MedRecordId { get; set; }
        public MedRecord MedRecord { get; set; }
    }
}