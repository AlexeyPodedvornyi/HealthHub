using HealthHub.Data;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class MedicalRecordService : IMedicalRecordService
    {
        public readonly IUnitOfWork _unitOfWork;

        public MedicalRecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetRecordIdAsync(int patientId)
        {
            return await _unitOfWork.MedicalRecordRepository.GetPatientRecordAsync(patientId);
        }
    }
}
