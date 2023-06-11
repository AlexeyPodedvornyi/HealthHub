using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Other;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class MedicalRecordAddViewModel : ViewModel
    {
        IMedicalHistoryService _medicalHistoryService;
        IDialogService _dialogService;
        IMedicalRecordService _medicalRecordService;
        ICurrentUserService _currentUserService;
        private  string _healthIssues;
        private  string _diagnosis;
        private  string _treatmentProtocol;
        private int _medicalRecordId;
        private PatientTreatment _patientTreatment;

        public string HealthIssues 
        { 
            get => _healthIssues;
            set 
            {
                _healthIssues = value; 
                OnPropertyChanged(nameof(HealthIssues));
            } 
        }
        public string Diagnosis
        {
            get => _diagnosis;
            set
            {
                _diagnosis = value;
                OnPropertyChanged(nameof(Diagnosis));
            }
        }
        public string TreatmentProtocol
        {
            get => _treatmentProtocol;
            set
            {
                _treatmentProtocol = value;
                OnPropertyChanged(nameof(TreatmentProtocol));
            }
        }
        public int PatientId { get; set; }

        public ICommand ResetBoxesValueCommand { get; }
        public ICommand AddMedicalHistoryRecordCommand { get; }
        public MedicalRecordAddViewModel(IMedicalHistoryService medicalHistoryService, IDialogService dialogService, IMedicalRecordService medicalRecordService,
            ICurrentUserService currentUserService)
        {
            _medicalHistoryService = medicalHistoryService;
            _dialogService = dialogService;
            _medicalRecordService = medicalRecordService;
            _currentUserService = currentUserService;

            ResetBoxesValueCommand = new RelayCommand(execute => ResetBoxesValue());
            AddMedicalHistoryRecordCommand = new RelayCommand(async execute => await AddNewHistoryRecordAsync());
        }

        private void ResetBoxesValue()
        {
            HealthIssues = string.Empty;
            Diagnosis = string.Empty;
            TreatmentProtocol = string.Empty;
        }

        private async Task AddNewHistoryRecordAsync()
        {
            if (string.IsNullOrEmpty(HealthIssues) || string.IsNullOrEmpty(Diagnosis) || string.IsNullOrEmpty(TreatmentProtocol))
            {
                _dialogService.ShowError("Поля не можуть бути пустими!\n Заповніть усі поля","Помилка");
                return;
            }
            await InitializePatientTreatment();
            var res = await _medicalHistoryService.AddHistoryRecord(_patientTreatment, _medicalRecordId);     
            
            if(!res)
                _dialogService.ShowError("Можливо Ви намагаєтесь внести запис про користувача який не зареєстрований на сьогоднішній прийом", "Помилка додавання даних");
            else
            {
                _dialogService.ShowInformation("Запис успішно додано до медкартки", "Операція успішна");
            }
        }

        private async Task InitializePatientTreatment()
        {
            _patientTreatment = new PatientTreatment();
            _medicalRecordId = await _medicalRecordService.GetRecordIdAsync(PatientId);
            _patientTreatment.Id = default;
            _patientTreatment.PatId = PatientId;
            _patientTreatment.HealthIssues = HealthIssues;
            _patientTreatment.Diagnosis = Diagnosis;
            _patientTreatment.TreatmentProtocol = TreatmentProtocol;

            if(_currentUserService.CurrentUser is DocAuthInfo doc)
            {
                _patientTreatment.DocId = doc.DocId;
            }
        } 
    }
}
