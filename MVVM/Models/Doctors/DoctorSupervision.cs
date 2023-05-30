using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class DoctorSupervision
    {
        public int Id { get; set; }

        public int DocId { get; set; }

        public int PatId { get; set; }

        public int Diagnosis { get; set; }

        public int ExamsFreq { get; set; }

        public virtual Doctor Doc { get; set; } = null!;

        public virtual Patient Pat { get; set; } = null!;
    }
}
