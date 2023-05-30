using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public class SickLeave
    {
        public int Id { get; set; }

        public int HospitalId { get; set; }

        public int DocId { get; set; }

        public int PatId { get; set; }

        public string Diagnosis { get; set; } = null!;

        public DateOnly StartTerm { get; set; }

        public DateOnly EndTerm { get; set; }

        public virtual Doctor Doc { get; set; } = null!;

        public virtual Hospital Hospital { get; set; } = null!;

        public virtual Patient Pat { get; set; } = null!;
    }
}
