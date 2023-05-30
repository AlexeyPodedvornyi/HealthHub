using HealthHub.MVVM.Models.AuthInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.AuthInfo
{
    public interface IAuthInfoRepository<TEntity>  where TEntity : IUserAuthInfo
    {
        Task<TEntity> SelectAuthInfoAsync(string login, string pass);
    }
}
