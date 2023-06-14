using HealthHub.Data;
using HealthHub.Helpers;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class DoctorScheduleService : IDoctorScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public DoctorScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<DoctorsSchedule>> GetAllSchedulesAsync()
        {
            return await _unitOfWork.DoctorsScheduleRepository.GetAllAsync();
        }

        public async Task<List<DoctorsSchedule>> GetSchedulesByDoctorIdAsync(int doctorId)
        {
            return await _unitOfWork.DoctorsScheduleRepository.GetByDoctorIdAsync(doctorId);
        }

        public async Task<List<DoctorsSchedule>> GetSchedulesByDocNDateAsync(int? doctorId ,DateTime? startDate, DateTime? endDate)
        {
            if (doctorId.HasValue && startDate.HasValue && endDate.HasValue)
            {
                return await GetByDocNDateAsync(doctorId.Value, startDate.Value, endDate.Value);
            }
            else if(doctorId.HasValue && !startDate.HasValue && !endDate.HasValue)
            {
                return await _unitOfWork.DoctorsScheduleRepository.GetByDoctorIdAsync(doctorId.Value);
            }
            else if (startDate.HasValue && endDate.HasValue)
            {
                return await GetDateRangedSchedulesAsync(startDate.Value, endDate.Value);
            }
            else if (startDate.HasValue)
            {
                return await GetSchedulesByDateAsync(startDate.Value);
            }

            return new List<DoctorsSchedule>();
        }

        private async Task<List<DoctorsSchedule>> GetByDocNDateAsync(int doctorId, DateTime startDate, DateTime endDate)
        {
            var doctorsSchedules = new List<DoctorsSchedule>();

            for (var iDate = startDate; iDate <= endDate; iDate = iDate.AddDays(1))
            {
                var daySchedule = await _unitOfWork.DoctorsScheduleRepository.GetByDocIdNDateAsync(doctorId, DateTimeConverter.ConvertToDateOnly(iDate));
                doctorsSchedules.AddRange(daySchedule);
            }

            return doctorsSchedules;
        }

        private async Task<List<DoctorsSchedule>> GetDateRangedSchedulesAsync(DateTime startDate, DateTime endDate)
        {
            var doctorsSchedules = new List<DoctorsSchedule>();

            for (var iDate = startDate; iDate <= endDate; iDate = iDate.AddDays(1))
            {
                var daySchedule = await _unitOfWork.DoctorsScheduleRepository.GetByBaseDateAsync(DateTimeConverter.ConvertToDateOnly(iDate));
                doctorsSchedules.AddRange(daySchedule);
            }

            return doctorsSchedules;
        }

        private async Task<List<DoctorsSchedule>> GetSchedulesByDateAsync(DateTime startDate)
        {
            return await _unitOfWork.DoctorsScheduleRepository.GetByBaseDateAsync(DateTimeConverter.ConvertToDateOnly(startDate));
        }
    }
}
