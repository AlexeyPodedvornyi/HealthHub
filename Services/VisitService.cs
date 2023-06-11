using HealthHub.Data;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class VisitService : IVisitService
    {
        public readonly IUnitOfWork _unitOfWork;

        public VisitService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<(int, DateOnly)> GetShortVisitInfoAsync(int visitId)
        {
            return await _unitOfWork.VisitRepository.GetShortVisitInfoAsync(visitId);
        }

        public async Task<int> GetVisitIdAsync(int patientId, int doctorId, DateOnly currentDate)
        {
            return await _unitOfWork.VisitRepository.GetVisitIdAsync(patientId, doctorId, currentDate);
        }

        public async Task<(int, DateOnly)> GetVisitInfoAsync(int visitId)
        {
            return await _unitOfWork.VisitRepository.GetShortVisitInfoAsync(visitId);
        }
    }
}
