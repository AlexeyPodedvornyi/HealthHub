using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Interfaces
{
    public interface ICurrentUserService
    {
        string CurrentRole { get; set; }
        IUserAuthInfo? CurrentUser { get; set; }
    }
}
