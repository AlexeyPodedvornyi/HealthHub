using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public partial class MedicalHistory
    {
        public int Id { get; set; }

        public int MedicalRecordId { get; set; }

        public int VisitId { get; set; }

        public int TreatmentId { get; set; }

        public int? SupervisionId { get; set; }

        public virtual MedicalRecord MedicalRecord { get; set; } = null!;

        public virtual DoctorSupervision? Supervision { get; set; }

        public virtual PatientTreatment Treatment { get; set; } = null!;

        public virtual Visit Visit { get; set; } = null!;
    }

}
