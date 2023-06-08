using HealthHub.Core;
using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.ViewModels.Presentations
{
    public class MedicalHistoryPresentation : ObservableObject
    {
        public string Diagnosis { get; set; }
        public DateOnly VisitDate { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSpecialty { get; set; }   
        public PatientTreatment PatientTreatment { get; set; }
        //public List<PatientTreatment> patientTreatments { get; set; }      

    }
}
