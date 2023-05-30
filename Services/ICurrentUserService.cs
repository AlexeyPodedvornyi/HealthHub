using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public interface ICurrentUserService
    {
        string CurrentRole { get; set; }
    }
}
