using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class Position
    {
        public int PosId { get; set; }

        public string Post { get; set; } = null!;

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
