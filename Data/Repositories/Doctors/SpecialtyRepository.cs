using HealthHub.MVVM.Models.Doctors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Doctors
{
    public class SpecialtyRepository : Repository<Specialty>
    {
        private readonly DbContext _dbContext;
        public SpecialtyRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetSpecialtyName(int specId)
        {
            return await _dbContext.Set<Specialty>()
                .Where(spec => spec.SpecId == specId)
                .Select(spec => spec.SpecName)
                .FirstAsync();
        }
    }
}
