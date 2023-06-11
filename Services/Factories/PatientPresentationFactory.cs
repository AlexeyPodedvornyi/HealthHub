using HealthHub.MVVM.Models.Patients;
using HealthHub.MVVM.ViewModels.Presentations;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public class PatientViewModelFactory : IPatientViewModelFactory
    {
        private readonly ICityService _cityService;
        public PatientViewModelFactory(ICityService cityService) 
        {
            _cityService = cityService;
        }

        public PatientPresentation Create(Patient patient)
        {
            return new PatientPresentation(patient, _cityService);
        }
    }
}
