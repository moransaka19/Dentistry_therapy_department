using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProcedureTotalPrice
    {
        public MedRecord MedRecord { get; set; }
        public Procedure Procedure { get; set; }
        public decimal Price { get; set; }
    }
}
