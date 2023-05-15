﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public interface IConnectionProviderFactory
    {
        IConnectionProvider? Create(string role);
    }
}