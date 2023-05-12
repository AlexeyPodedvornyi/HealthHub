using HealthHub.MVVM.Model;
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
        IUser? CreateUser(IDataRecord record);
        IUser? Create(IDataRecord record, string role);
    }
}
