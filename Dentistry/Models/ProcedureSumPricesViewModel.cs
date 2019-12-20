using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class ProcedureSumPricesViewModel
    {
        private decimal _sumPrices;
        public ProcedureViewModel Procedure { get; set; }
        public decimal SumPrices 
        { 
            get
            {
                return Math.Round(_sumPrices);
            }
            set
            {
                _sumPrices = value;
            }
        }
    }
}
