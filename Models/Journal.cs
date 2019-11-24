using System;

namespace Dentistry_therapy_department.Models
{
    public class Journal
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int ProcedureId { get; set; }
        public int MedRecordId { get; set; }
    }
}