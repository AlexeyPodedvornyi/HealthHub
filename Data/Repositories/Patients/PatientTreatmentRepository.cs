﻿using HealthHub.MVVM.Models.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data.Repositories.Patients
{
    public class PatientTreatmentRepository : Repository<PatientTreatment>
    {
        private readonly DbContext _dbContext;
        public PatientTreatmentRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PatientTreatment>> GetPatientTreatmentAsync(int patientId)
        {
            return await _dbContext.Set<PatientTreatment>()
                .Where(treatment => treatment.PatId == patientId)
                .ToListAsync();
        }
    }
}
