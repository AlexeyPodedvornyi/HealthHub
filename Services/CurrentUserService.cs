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
        public string CurrentRole { get; set; }
        public IUserAuthInfo? CurrentUser { get; set; }

        public CurrentUserService()
        {
            // Uncoment when authWindow is the startup Window
            //CurrentRole = "unauthorized";
            CurrentUser = new DocAuthInfo { DocId = 18};
            CurrentRole = "doctor";

        }

    }
}
