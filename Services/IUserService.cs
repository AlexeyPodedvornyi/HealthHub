﻿using HealthHub.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public interface IUserService
    {
        IUser? GetUser(string login);
    }
}
