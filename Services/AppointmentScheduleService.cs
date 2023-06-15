using HealthHub.Data;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class AppointmentScheduleService : IAppointmentScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        public AppointmentScheduleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task AddAppointementScheduleAsync(AppointmentSchedule appointmentSchedule, bool saveChanges = true)
        {
            await _unitOfWork.AppointmentScheduleRepository.AddAsync(appointmentSchedule);

            if(saveChanges)
                await _unitOfWork.SaveChangesAsync();
        }
        
    }
}
