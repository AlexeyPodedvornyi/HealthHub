using HealthHub.Data;
using HealthHub.Helpers;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class PatientTreatmentService : IPatientTreatmentService
    {
        public readonly IUnitOfWork _unitOfWork;

        public PatientTreatmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PatientTreatment>>GetPatientTreatments(int patientId)
        {
            return await _unitOfWork.PatientTreatmentRepository.GetPatientTreatmentAsync(patientId);
        }

        public async Task AddPatientTreatment(PatientTreatment patientTreatment)
        {
            await _unitOfWork.PatientTreatmentRepository.AddAsync(patientTreatment);
            await _unitOfWork.SaveChangesAsync();
        }


        public async Task<PatientTreatment?> GetPatientTreatmentAsync(int treatmentId)
        {
            return await _unitOfWork.PatientTreatmentRepository.GetByIdAsync(treatmentId);
        }

        public async Task<List<PatientTreatment>> GetTodayTreatments(int patientId)
        {
            return await _unitOfWork.PatientTreatmentRepository.GetTodayTreatments(patientId, DateTimeConverter.ConvertToDateOnly(DateTime.Now));
        }
    }
}
