using HealthHub.Data;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Patients;
using HealthHub.MVVM.ViewModels.Presentations;
using HealthHub.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class MedicalHistoryService : IMedicalHistoryService
    {
        public readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IVisitService _visitService;
        private readonly IPatientTreatmentService _patientTreatmentService;

        public MedicalHistoryService(IUnitOfWork unitOfWork, ICurrentUserService currentUserService, IVisitService visitService, IPatientTreatmentService patientTreatmentService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
            _visitService = visitService;
            _patientTreatmentService = patientTreatmentService;
        }

        public async Task<List<MedicalHistory>> GetMedicalHistoryAsync(int medicalRecordId)
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
                var visit = await _visitService.GetVisitInfoAsync(history.VisitId);
                var treatment = await _patientTreatmentService.GetPatientTreatmentAsync(history.TreatmentId);
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

        public async Task<bool> AddHistoryRecord(PatientTreatment patientTreatment, int medicalRecordId)
        {
            var currentDate = DateTime.Now.Date;
            var visitId = await _visitService.GetVisitIdAsync(patientTreatment.PatId, patientTreatment.DocId, new DateOnly(currentDate.Year, currentDate.Month, currentDate.Day));

            if (visitId == 0)
                return false;

            await _patientTreatmentService.AddPatientTreatment(patientTreatment);
            
            var medHistory = new MedicalHistory
            {
                MedicalRecordId = medicalRecordId,
                VisitId = visitId,
                TreatmentId = patientTreatment.Id,
                Treatment = patientTreatment
            };

            
            await _unitOfWork.MedicalHistoryRepository.AddAsync(medHistory);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        

        private async Task<Doctor?> GetDoctorAsync(int doctorId) // TODO: Вынести в свой сервис 
        {
            return await _unitOfWork.DoctorRepository.GetByIdAsync(doctorId);
        }


    }
}
