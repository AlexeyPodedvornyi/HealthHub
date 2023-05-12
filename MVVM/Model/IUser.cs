using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Model
{
    public interface IUser
    {
        string Login { get; }
        string Password { get; }
    }
}
