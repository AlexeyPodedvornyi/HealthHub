using HealthHub.MVVM.Models.Doctors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Doctors
{
    public class DoctorsScheduleRepository : Repository<DoctorsSchedule>
    {
        private readonly DbContext _dbContext;
        public DoctorsScheduleRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DoctorsSchedule>> GetAllAsync()
        {
            return await _dbContext.Set<DoctorsSchedule>()
                .Include(d => d.Doc)
                    .ThenInclude(doc => doc.Spec)
                .ToListAsync();
        }

        public async Task<List<DoctorsSchedule>> GetByDoctorIdAsync(int doctorId)
        {
            return await _dbContext.Set<DoctorsSchedule>()
                .Include(d => d.Doc)
                    .ThenInclude(doc => doc.Spec)
                .Where(d => d.DocId == doctorId)
                .ToListAsync();
        }

        public async Task<List<DoctorsSchedule>> GetByBaseDateAsync(DateOnly date)
        {
            return await _dbContext.Set<DoctorsSchedule>()
                .Include(d => d.Doc)
                    .ThenInclude(doc => doc.Spec)
                .Where(d => d.BaseDate == date)
                .ToListAsync();
        }

        public async Task<List<DoctorsSchedule>> GetByDocIdNDateAsync(int doctorId, DateOnly date)
        {
            return await _dbContext.Set<DoctorsSchedule>()
                .Include (d => d.Doc)
                    .ThenInclude(doc => doc.Spec)
                .Where(d => d.DocId == doctorId && d.BaseDate == date)
                .ToListAsync();
        }
    }
}
