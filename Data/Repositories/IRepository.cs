using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity?> GetByIdAsync(int id);
        void Update(TEntity entity);

    }
}
