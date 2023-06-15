using HealthHub.Data;
using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.Services.Factories;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthHub.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public enum UserRole
        {
            Unauthorized,
            Admin,
            Doctor,
            DepartmentHead
        }
        public UserRole CurrentRole { get; set; }
        public IUserAuthInfo? CurrentUser { get; set; }

        public CurrentUserService()
        {
            CurrentRole = UserRole.Unauthorized;
        }

    }
}
