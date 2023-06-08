using HealthHub.MVVM.Models.Doctors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Doctors
{
    public class DoctorSupervisionRepository : Repository<DoctorSupervision>
    {
        private readonly DbContext _dbContext;
        public DoctorSupervisionRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DoctorSupervision>> GetDoctorSupervisionsByPatientIdAsync(int patientId)
        {
            return await _dbContext.Set<DoctorSupervision>()
                .Where(supervision => supervision.PatId == patientId)
                .ToListAsync();
        }
    }
}
