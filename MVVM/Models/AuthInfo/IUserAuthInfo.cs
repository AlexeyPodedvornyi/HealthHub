using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.AuthInfo
{
    public interface IUserAuthInfo
    {
        string Login { get; }
        string Password { get; }
    }
}
