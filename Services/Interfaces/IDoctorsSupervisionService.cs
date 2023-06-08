using HealthHub.MVVM.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface IDoctorsSupervisionService
    {
        Task<List<DoctorSupervision>> GetSupervisionsListAsync(int patientId);

    }
}
