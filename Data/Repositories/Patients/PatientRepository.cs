using HealthHub.MVVM.Models.Patients;
using HealthHub.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthHub.Data.Repositories.Patients
{
    public class PatientRepository : Repository<Patient>
    {
        private readonly DbContext _dbContext;
        
        public PatientRepository(DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        /// <summary>
        /// Performs search for patients by full name.
        /// </summary>
        /// <param name="fullName"> string with Patient`s full name.</param>
        /// <returns>List of patients matching the search criteria.</returns>
        public async Task<List<Patient>> GetPatientsByFullNameAsync(string fullName)
        {
            // Split the full name by spaces and handle every part of full name (first,last,middle) as part of an array.
            var names = fullName.Split(' ');
            if (names.Length == 1)
            {
                return await _dbContext.Set<Patient>()
                    .Where(p => p.FirstName == names[0] || p.LastName == names[0])
                    .ToListAsync();
            }
            else if (names.Length == 2)
            {
                return await _dbContext.Set<Patient>()
                    .Where(p => (p.FirstName == names[0] && p.LastName == names[1]) 
                        || (p.FirstName == names[1] && p.LastName == names[0]))
                    .ToListAsync();
            }
            else if (names.Length == 3)
            {
                return await _dbContext.Set<Patient>()
                    .Where(p => p.FirstName == names[0] && p.LastName == names[2] && p.MiddleName == names[1])
                    .ToListAsync();
            }

            return new List<Patient>();
        }

       
    }
}
