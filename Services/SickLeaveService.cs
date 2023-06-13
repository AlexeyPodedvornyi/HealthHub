using HealthHub.Data;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class SickLeaveService : ISickLeaveService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SickLeaveService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<SickLeave>> GetSickLeavesAsync(int patientId)
        {
           return await _unitOfWork.SickLeaveRepository.GetSickLeavesAsync(patientId);
        }

        public async Task AddSickLeaveAsync(SickLeave sickLeave)
        {
            await _unitOfWork.SickLeaveRepository.AddAsync(sickLeave);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
