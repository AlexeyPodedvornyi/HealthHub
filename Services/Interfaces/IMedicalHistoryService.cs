using HealthHub.MVVM.Models.Patients;
using HealthHub.MVVM.ViewModels.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface IMedicalHistoryService
    {
        Task<List<MedicalHistory>> GetMedicalHistoryAsync(int medicalRecordId);
        Task<List<MedicalHistoryPresentation>> GetPatientHistoryAsync(int patientId);

        Task<bool> AddHistoryRecord(PatientTreatment patientTreatment, int medicalRecordId);
    }
}
