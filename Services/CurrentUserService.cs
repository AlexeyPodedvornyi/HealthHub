using HealthHub.Services.Factories;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string CurrentRole { get; set; }

        public CurrentUserService()
        {   
            // Uncoment when authWindow is the startup Window
            //CurrentRole = "unauthorized";
            CurrentRole = "doctor";

        }

    }
}
