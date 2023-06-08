using HealthHub.MVVM.Models.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Patients
{
    public class MedicalHistoryRepository : Repository<MedicalHistory>
    {
        private readonly DbContext _dbContext;
        public MedicalHistoryRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext; 
        }

        public async Task<List<MedicalHistory>> GetPatientsMedicalHistoryAsync(int medicalRecordId)
        {
            return await _dbContext.Set<MedicalHistory>()
                .Where(history => history.MedicalRecordId == medicalRecordId)
                .ToListAsync();
        }
    }
}
