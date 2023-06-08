using HealthHub.MVVM.Models.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Other
{
    public class MedicalRecordRepository : Repository<MedicalRecord>
    {
        private readonly DbContext _dbContext;
        public MedicalRecordRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> GetPatientRecordAsync(int patientId)
        {
            return await _dbContext.Set<MedicalRecord>()
                .Where(record => record.PatId == patientId)
                .Select(record => record.Id)
                .FirstAsync();
        }
    }
}
