﻿using HealthHub.MVVM.Models.Doctors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Doctors
{
    public class DoctorRepository : Repository<Doctor>
    {
        private readonly DbContext _dbContext;
        public DoctorRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
