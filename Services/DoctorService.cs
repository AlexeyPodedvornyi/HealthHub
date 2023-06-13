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
    public class DoctorService : IDoctorService
    {
        public readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> GetHospitalIdAsync(int doctorId)
        {
            return await _unitOfWork.DoctorRepository.GetHospitalIdAsync(doctorId);
        }
    }
}
