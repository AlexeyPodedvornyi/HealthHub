using HealthHub.MVVM.Models.AuthInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public interface IUserService
    {
        IUserAuthInfo? GetUser(string login);
    }
}
