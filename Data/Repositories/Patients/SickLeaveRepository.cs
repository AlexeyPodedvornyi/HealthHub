using HealthHub.MVVM.Models.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Patients
{
    public class SickLeaveRepository : Repository<SickLeave>
    {
        private readonly DbContext _dbContext;
        public SickLeaveRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<SickLeave>> GetSickLeavesAsync(int patientId)
        {
            return await _dbContext.Set<SickLeave>()
                .Include(s => s.Treatment)
                    .ThenInclude(t => t.Doc)
                .Include(s => s.Hospital)
                .Where(s => s.Treatment.PatId == patientId)
                .ToListAsync();
        }
    }
}
