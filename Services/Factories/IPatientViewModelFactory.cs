using HealthHub.MVVM.Models.Patients;
using HealthHub.MVVM.ViewModels.Presentations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public interface IPatientViewModelFactory
    {
        PatientPresentation Create(Patient patient);
    }
}
