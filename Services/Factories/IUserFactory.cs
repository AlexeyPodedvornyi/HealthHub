using HealthHub.MVVM.Models.AuthInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public interface IUserFactory
    {
        IUserAuthInfo? CreateUser(IDataRecord record);
        IUserAuthInfo? Create(IDataRecord record, string role);
    }
}
