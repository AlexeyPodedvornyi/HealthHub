using HealthHub.Data;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PatientService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Patient>> SearchAsync(string searchRequest)
        {
            return await _unitOfWork.PatientRepository.GetPatientsByFullNameAsync(searchRequest);
        }


    }
}
