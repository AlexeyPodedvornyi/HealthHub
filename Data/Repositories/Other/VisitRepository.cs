using HealthHub.MVVM.Models.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Other
{
    public class VisitRepository : Repository<Visit>
    {
        private readonly DbContext _dbContext;

        public VisitRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(int, DateOnly)> GetShortVisitInfoAsync(int visitId)
        {
            var visit =  await _dbContext.Set<Visit>()
                .Where(visit => visit.VisitId == visitId)
                .FirstAsync();

            return (visit.DocId, visit.VisitDate);
        }

        public async Task<int> GetVisitIdAsync(int patientId, int doctorId, DateOnly currentDate)
        {
            bool isVisitExists = await _dbContext.Set<Visit>()
                .AnyAsync(visit => visit.PatId == patientId && visit.DocId == doctorId && visit.VisitDate == currentDate);

            if (!isVisitExists)
            {
                return 0;
            }

            int visitId = await _dbContext.Set<Visit>()
                .Where(visit => visit.PatId == patientId && visit.DocId == doctorId && visit.VisitDate == currentDate)
                .Select(visit => visit.VisitId)
                .FirstAsync();

            return visitId;
        }
    }
}
