using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public partial class SickLeave
    {
        public int Id { get; set; }

        public int HospitalId { get; set; }

        public DateOnly StartTerm { get; set; }

        public DateOnly EndTerm { get; set; }

        public int TreatmentId { get; set; }

        public virtual Hospital Hospital { get; set; } = null!;

        public virtual PatientTreatment Treatment { get; set; } = null!;
    }
}
