using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Interfaces
{
    public interface IUser
    {
        string Login { get; set; }
        string Password { get; set; }
    }
}
