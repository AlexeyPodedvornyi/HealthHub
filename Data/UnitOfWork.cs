using HealthHub.Data.Repositories.AuthInfo;
using HealthHub.MVVM.Models.AuthInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public AdminAuthInfoRepository AdminAuthInfoRepository { get; private set; }
        public DocAuthInfoRepository DocAuthInfoRepository { get; private set; }
        public UnitOfWork(DbContext dbContext, AdminAuthInfoRepository adminAuthInfoRepository, DocAuthInfoRepository docAuthInfoRepository)
        {
            _dbContext = dbContext;
            AdminAuthInfoRepository = adminAuthInfoRepository;
            DocAuthInfoRepository = docAuthInfoRepository;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
