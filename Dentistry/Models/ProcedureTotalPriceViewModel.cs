using AutoMapper;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Dentistry.Models
{
    public class ProcedureTotalPriceViewModel
    {
        private decimal _price;

        public MedRecordViewModel MedRecord { get; set; }
        public ProcedureViewModel Procedure { get; set; }
        public JournalViewModel Journal { get; set; }
        public decimal Price 
        { 
            get => MedRecord.DOB.DayOfYear == Journal.ExecutingDate.DayOfYear ? Math.Round(_price / 2, 2) : Math.Round(_price); 
            set => _price = value; 
        }
    }
}
