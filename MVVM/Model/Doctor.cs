﻿using HealthHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Model
{
    [Serializable]
    public class Doctor : IUser
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public Doctor(string login, string password, string role) 
        {
            Login = login;
            Password = password;
            Role = role;
        }

    }
}
