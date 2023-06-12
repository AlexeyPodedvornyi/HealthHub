using HealthHub.MVVM.Models.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Patients
{
    public class RecipeRepository : Repository<Recipe>
    {
        private readonly DbContext _dbContext;
        public RecipeRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Recipe>> GetRecipesAsync(int patientId)
        {
            return await _dbContext.Set<Recipe>()
                .Include(r => r.Doc)
                .Where(r => r.PatId == patientId)
                .ToListAsync();
        }
    }
}
