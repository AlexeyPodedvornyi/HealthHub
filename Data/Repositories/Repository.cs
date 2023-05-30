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
        public void Add(TEntity entity)
        {
            _hospitalContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _hospitalContext.Set<TEntity>().Remove(entity);
        }

        public TEntity GetById(int id)
        {
            return _hospitalContext.Set<TEntity>().Find(id)!;
        }

        public void Update(TEntity entity)
        {
            _hospitalContext?.Set<TEntity>().Update(entity);
        }
    }
}
