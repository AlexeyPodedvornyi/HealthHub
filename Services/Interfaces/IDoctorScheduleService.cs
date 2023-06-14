using HealthHub.MVVM.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface IDoctorScheduleService
    {
        Task<List<DoctorsSchedule>> GetAllSchedulesAsync();
        Task<List<DoctorsSchedule>> GetSchedulesByDoctorIdAsync(int doctorId);
        Task<List<DoctorsSchedule>> GetSchedulesByDocNDateAsync(int? doctorId, DateTime? startDate, DateTime? endDate);
    }
}
