using HealthHub.Data;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class DoctorsSupervisionService : IDoctorsSupervisionService
    {
        public readonly IUnitOfWork _unitOfWork;

        public DoctorsSupervisionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DoctorSupervision>> GetSupervisionsListAsync(int patientId)
        {
            return await _unitOfWork.DoctorSupervisionRepository.GetDoctorSupervisionsByPatientIdAsync(patientId);
        }
    }
}
