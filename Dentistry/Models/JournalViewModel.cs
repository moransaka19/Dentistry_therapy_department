using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dentistry.Models
{
    public class JournalViewModel
    {
		public int JournalId { get; set; }
		public DateTime CreatedOn { get; set; }
		public int DoctorId { get; set; }
		public DoctorViewModel Doctor { get; set; }
		public int ProcedureId { get; set; }
		public ProcedureViewModel Procedure { get; set; }
		public int MedRecordId { get; set; }
		public MedRecordViewModel MedRecord { get; set; }

		public IEnumerable<DoctorViewModel> Doctors { get; set; }
		public IEnumerable<ProcedureViewModel> Procedures { get; set; }
		public IEnumerable<MedRecordViewModel> MedRecords { get; set; }
	}
}
