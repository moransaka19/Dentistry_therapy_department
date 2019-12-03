using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dentistry.Models
{
    public class ProcedureTotalPriceViewModel
    {
        public MedRecordViewModel MedRecord { get; set; }
        public ProcedureViewModel Procedure { get; set; }
        public decimal Price { get; set; }
    }
}
