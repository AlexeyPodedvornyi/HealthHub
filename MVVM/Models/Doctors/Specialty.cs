using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class Specialty
    {
        public int SpecId { get; set; }

        public string SpecName { get; set; } = null!;

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
