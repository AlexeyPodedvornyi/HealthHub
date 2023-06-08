using HealthHub.Services.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _hospitalContext;
        public Repository(DbContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
            
        }
        public async Task AddAsync(TEntity entity)
        {
            await _hospitalContext.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _hospitalContext.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _hospitalContext.Set<TEntity>().FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            _hospitalContext.Set<TEntity>().Update(entity);
        }
    }
}
