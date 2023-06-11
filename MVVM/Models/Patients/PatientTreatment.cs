using HealthHub.MVVM.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public partial class PatientTreatment
    {
        public int Id { get; set; }

        public int PatId { get; set; }

        public int DocId { get; set; }

        public string HealthIssues { get; set; } = null!;

        public string Diagnosis { get; set; } = null!;

        public string TreatmentProtocol { get; set; } = null!;

        public virtual Doctor Doc { get; set; } = null!;

        public virtual MedicalHistory? MedicalHistory { get; set; }

        public virtual Patient Pat { get; set; } = null!;

        public virtual ICollection<SickLeave> SickLeavs { get; set; } = new List<SickLeave>();
    }
}
