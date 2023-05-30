using HealthHub.Data.Repositories.AuthInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data
{
    public interface IUnitOfWork
    {
        AdminAuthInfoRepository AdminAuthInfoRepository { get; }
        DocAuthInfoRepository DocAuthInfoRepository { get;  }
        void Commit();
    }
}
