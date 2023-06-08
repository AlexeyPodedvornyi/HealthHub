using HealthHub.Core;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.ViewModels.Presentations
{
    public class PatientPresentation : ObservableObject
    {
        private readonly Patient _patient;
        private readonly ICityService _cityService;

        public int PatId
        {
            get => _patient.PatId;
            set
            {
                _patient.PatId = value;
                OnPropertyChanged(nameof(PatId));
            }
        }
        public string FirstName
        {
            get => _patient.FirstName;
            set
            {
                _patient.FirstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string LastName
        {
            get => _patient.LastName;
            set
            {
                _patient.LastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        public string? MiddleName
        {
            get => _patient.MiddleName;
            set
            {
                _patient.MiddleName = value;
                OnPropertyChanged(nameof(MiddleName));
            }
        }
        public DateOnly DateOfBirthday
        {
            get => _patient.DateOfBirthday;
            set
            {
                _patient.DateOfBirthday = value;
                OnPropertyChanged(nameof(DateOfBirthday));
            }
        }
        public int? FamilyId
        {
            get => _patient.FamilyId;
            set
            {
                _patient.FamilyId = value;
                OnPropertyChanged(nameof(FamilyId));
            }
        }
        public string Email
        {
            get => _patient.Email;
            set
            {
                _patient.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Gender
        {
            get => _patient.Gender;
            set
            {
                _patient.Gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }
        public string Address
        {
            get => _patient.Address;
            set
            {
                _patient.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public string CityName
        {
            get => _cityService.ConvertIdToName(_patient.CityId);
        }

        public PatientPresentation(Patient patient, ICityService cityService)
        {
            _patient = patient;
            _cityService = cityService;
        }

    }
}
