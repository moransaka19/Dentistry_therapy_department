using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dentistry.Models
{
    public class AddDoctorViewModel
    {
        public IEnumerable<DoctorViewModel> doctors { get; set; }

        public int DoctorId { get; set; }
    }
}
