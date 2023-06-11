using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface IVisitService
    {
        Task<(int, DateOnly)> GetShortVisitInfoAsync(int visitId);
        Task<(int, DateOnly)> GetVisitInfoAsync(int visitId);
        Task<int> GetVisitIdAsync(int patientId, int doctorId, DateOnly currentDate);


    }
}
