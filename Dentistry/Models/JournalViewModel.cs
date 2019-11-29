using System;
using System.Collections.Generic;
using System.Text;

namespace Dentistry.Models
{
    public class JournalViewModel
    {
        public DateTime Date { get; set; }
        public DoctorViewModel Doctor { get; set; }
        public ProcedureVIewModel Procedure { get; set; }
        public MedRecordViewModel MedRecord { get; set; }
    }
}
