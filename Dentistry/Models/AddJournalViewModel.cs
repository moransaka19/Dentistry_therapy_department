﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class AddJournalViewModel
    {
        public IEnumerable<DoctorViewModel> Doctors { get; set; }
        public IEnumerable<ProcedureVIewModel> Procedures { get; set; }
        public IEnumerable<MedRecordViewModel> MedRecords { get; set; }

        public int DoctorId { get; set; }
        public int ProcedureId { get; set; }
        public int MedRecordId { get; set; }
    }
}