using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.Models.Other;
using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public partial class Doctor
    {
        public int DocId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int HospitalId { get; set; }

        public int SpecId { get; set; }

        public int PosId { get; set; }

        public string MiddleName { get; set; } = null!;

        public virtual ICollection<AppointmentSchedule> AppointmentSchedules { get; set; } = new List<AppointmentSchedule>();

        public virtual DocAuthInfo? DocAuthInfo { get; set; }

        public virtual ICollection<DoctorSupervision> DoctorSupervisions { get; set; } = new List<DoctorSupervision>();

        public virtual ICollection<DoctorsSchedule> DoctorsSchedules { get; set; } = new List<DoctorsSchedule>();

        public virtual ICollection<Family> Families { get; set; } = new List<Family>();

        public virtual Hospital Hospital { get; set; } = null!;

        public virtual ICollection<PatientTreatment> PatientTreatments { get; set; } = new List<PatientTreatment>();

        public virtual Position Pos { get; set; } = null!;

        public virtual ICollection<Recipe> Recipies { get; set; } = new List<Recipe>();

        public virtual Specialty Spec { get; set; } = null!;

        public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
