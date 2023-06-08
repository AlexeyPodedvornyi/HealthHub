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
    }
}
