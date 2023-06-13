using HealthHub.Helpers;
using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class SickLeaveViewModel : ViewModel, IParameterizedNavigationViewModel
    {
        private readonly ISickLeaveService _sickLeaveService;
        private readonly IDialogService _dialogService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IDoctorService _doctorService;
        private readonly IPatientTreatmentService _patientTreatmentService;

        private Patient _patient;
        private List<SickLeave> _sickLeaves;
        private List<PatientTreatment> _todayTreatments;
        private SickLeave _selectedListItem;
        private DateTime? _endTerm;
        private PatientTreatment _comboboxSelectedItem;
        private string _treatmentInfo;


        public Patient Patient
        {
            get => _patient;
        }
        public List<SickLeave> SickLeaves
        {
            get => _sickLeaves;
            set
            {
                if (_sickLeaves != value)
                {
                    _sickLeaves = value;
                }
                OnPropertyChanged(nameof(SickLeaves));
            }
        }
        public List<PatientTreatment> TodayTreatments
        {
            get => _todayTreatments;
            set
            {
                if (_todayTreatments != value)
                {
                    _todayTreatments = value;
                }
                OnPropertyChanged(nameof(TodayTreatments));
            }
        }
        public SickLeave SelectedListItem
        {
            get => _selectedListItem;
            set
            {
                if (_selectedListItem != value)
                {
                    _selectedListItem = value;
                }
                OnPropertyChanged(nameof(SelectedListItem));
            }
        }
        public PatientTreatment ComboboxSelectedItem
        {
            get => _comboboxSelectedItem;
            set
            {               
                _comboboxSelectedItem = value;
                OnPropertyChanged(nameof(ComboboxSelectedItem));
            }
        }
        public DateTime? EndTerm
        {
            get => _endTerm;
            set
            {
                _endTerm = value;
                OnPropertyChanged(nameof(EndTerm));
            }
        }

        public string OwnerInfo
        {
            get
            {
                var fullname = $"{Patient.LastName} {Patient.FirstName}";
                if (!string.IsNullOrEmpty(Patient.MiddleName))
                    fullname += $" {Patient.MiddleName}";

                return fullname + "\t" + Patient.Gender + "\t" + Patient.DateOfBirthday;
            }
        }

        public string OwnerAddress
        {
            get
            {
                return Patient.City.CityName + "\n" + Patient.Address;
            }
        }

        public ICommand InitListsCommand { get; set; }
        public ICommand CreateSickLeaveCommand { get; }

        public SickLeaveViewModel(ISickLeaveService sickLeaveService, IDialogService dialogService, ICurrentUserService currentUserService,
            IPatientTreatmentService patientTreatmentService, IDoctorService doctorService)
        {
            _sickLeaveService = sickLeaveService;
            _dialogService = dialogService;
            _currentUserService = currentUserService;
            _patientTreatmentService = patientTreatmentService;
            _doctorService = doctorService;

            InitListsCommand = new RelayCommand(async exec => await InitListsAsync());
            CreateSickLeaveCommand = new RelayCommand(async exec => await CreateSickLeave());
        }

        public void InitializeParameters(object parameter)
        {
            if (parameter is Patient patient)
            {
                _patient = patient;
            }

            InitListsCommand.Execute(null);
        }

        private async Task InitListsAsync()
        {
            SickLeaves = await _sickLeaveService.GetSickLeavesAsync(Patient.PatId);
            TodayTreatments = await _patientTreatmentService.GetTodayTreatments(Patient.PatId);
        }

        private async Task CreateSickLeave()
        {
            if(_currentUserService.CurrentUser is DocAuthInfo doc)
            {
                var isInputsValid = ValidateInputs();
                if (!isInputsValid)
                    return;

                var sickLeave = new SickLeave
                {
                    HospitalId = await _doctorService.GetHospitalIdAsync(doc.DocId),
                    StartTerm = DateTimeConverter.ConvertToDateOnly(DateTime.Now.Date),
                    EndTerm = DateTimeConverter.ConvertToDateOnly(EndTerm),
                    TreatmentId = ComboboxSelectedItem.Id
                };

                await _sickLeaveService.AddSickLeaveAsync(sickLeave);
                _dialogService.ShowInformation("Лікарняний успішно створено!", "Операція успішна");
                InitListsCommand.Execute(null);
            }
        }

        private bool ValidateInputs()
        {
            if (EndTerm == null)
            {
                _dialogService.ShowError("Поле з датою не може бути пустим!", "Помилка даних");
                return false;
            }

            if (ComboboxSelectedItem == null)
            {
                _dialogService.ShowError("Обов'язково необхідно обрати номер звернення з випадаючого списку", "Помилка даних");
                return false;
            }

            if (EndTerm.Value.Date <= DateTime.Now)
            {
                _dialogService.ShowError("Кінцевий термін дії не може бути рівним або меншим за сьогоднішню дату", "Помилка даних");
                return false;
            }

            if (_sickLeaves.Any(s => s.TreatmentId == ComboboxSelectedItem.Id))
            {
                _dialogService.ShowError("Лікарняний за обраним зверненням вже існує!", "Помилка даних");
                return false;
            }            
 
            return true;
        }

    }
}
