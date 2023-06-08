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
    }
}
