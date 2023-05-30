using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.Services.Factories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.AuthInfo
{
    public class AdminAuthInfoRepository : Repository<AdminAuthInfo>, IAuthInfoRepository<AdminAuthInfo>
    {
        private readonly DbContext _dbContext;

        public AdminAuthInfoRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AdminAuthInfo> SelectAuthInfoAsync(string login, string pass)
        {
            return await _dbContext.Set<AdminAuthInfo>().FirstOrDefaultAsync(a => a.Login == login && a.Password == pass);
        }
    }
}
