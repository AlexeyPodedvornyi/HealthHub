using HealthHub.MVVM.Models.AuthInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.AuthInfo
{
    public class DocAuthInfoRepository : Repository<DocAuthInfo>, IAuthInfoRepository<DocAuthInfo>
    {
        private readonly DbContext _dbContext;

        public DocAuthInfoRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<DocAuthInfo> SelectAuthInfoAsync(string login, string pass)
        {
            return await _dbContext.Set<DocAuthInfo>()
                .Include(d => d.Role)
                .FirstOrDefaultAsync(a => a.Login == login && a.Password == pass);
        }
    }
}
