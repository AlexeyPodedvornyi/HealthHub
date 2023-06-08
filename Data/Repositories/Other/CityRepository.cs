using HealthHub.MVVM.Models.Other;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Other
{
    public class CityRepository : Repository<City>
    {
        private readonly DbContext _dbContext;
        public CityRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> GetCityNameByIdAsync(int id)
        {
            return await _dbContext.Set<City>()
                .Where(c => c.CityId == id)
                .Select(c => c.CityName)
                .FirstAsync();
        }

        public string GetCityNameById(int id)
        {
            return _dbContext.Set<City>()
                .Where(c => c.CityId == id)
                .Select(c => c.CityName)
                .First();
        }
    }
}
