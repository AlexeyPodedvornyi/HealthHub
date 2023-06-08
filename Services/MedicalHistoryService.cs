using HealthHub.Data;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Patients;
using HealthHub.MVVM.ViewModels.Presentations;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        public readonly IUnitOfWork _unitOfWork;

        public MedicalHistoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<MedicalHistory>> GetReocordHistoryAsync(int medicalRecordId)
        {
            return await _unitOfWork.MedicalHistoryRepository.GetPatientsMedicalHistoryAsync(medicalRecordId);
        }

        public async Task<List<MedicalHistoryPresentation>> GetPatientHistoryAsync(int patientId)
        {
            var recordId = await _unitOfWork.MedicalRecordRepository.GetPatientRecordAsync(patientId);
            var historyList = await _unitOfWork.MedicalHistoryRepository.GetPatientsMedicalHistoryAsync(recordId);

            var result = new List<MedicalHistoryPresentation>();

            foreach (var history in historyList)
            {
                var visit = await GetVisitInfoAsync(history.VisitId);
                var treatment = await GetPatientTreatmentAsync(history.TreatmentId);
                var doc = await GetDoctorAsync(treatment!.DocId);

                result.Add(new MedicalHistoryPresentation
                {
                    PatientTreatment = treatment,
                    Diagnosis = treatment.Diagnosis,
                    DoctorName = $"{doc!.LastName}  {doc.FirstName}  {doc.MiddleName}",
                    VisitDate = visit.Item2,
                    DoctorSpecialty = await _unitOfWork.SpecialtyRepository.GetSpecialtyName(doc.SpecId)
                }) ;
            }

            return result;
        }

        private async Task<(int, DateOnly)> GetVisitInfoAsync(int visitId)
        {
            return await _unitOfWork.VisitRepository.GetShortVisitInfoAsync(visitId);
        }

        private async Task<PatientTreatment?> GetPatientTreatmentAsync(int treatmentId)
        {
            return await _unitOfWork.PatientTreatmentRepository.GetByIdAsync(treatmentId);
        }

        private async Task<Doctor?> GetDoctorAsync(int doctorId) // TODO: Вынести в свой сервис 
        {
            return await _unitOfWork.DoctorRepository.GetByIdAsync(doctorId);
        }
    }
}
