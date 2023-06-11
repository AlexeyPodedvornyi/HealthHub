using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Input;
using HealthHub.MVVM.Commands;
using HealthHub.MVVM.ViewModels.Presentations;
using HealthHub.MVVM.Views;
using HealthHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HealthHub.MVVM.ViewModels
{
    public class MedicalRecordViewModel : ViewModel, IParameterizedNavigationViewModel
    {
        private PatientPresentation _patient;
        private readonly IMedicalHistoryService _medicalHistoryService;
        private readonly MedicalRecordAddViewModel _medicalRecordAddViewModel;
        private List<MedicalHistoryPresentation> _medicalHistoryPresentations;
        private MedicalHistoryPresentation _selectedListItem;

        public string OwnerInfo {
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
                return Patient.CityName + "\n" + Patient.Address;
            }
        }

        public MedicalHistoryPresentation SelectedListItem
        {
            get => _selectedListItem;
            set
            {
                _selectedListItem = value;
                OnPropertyChanged(nameof(SelectedListItem));
            }
        }

        public List<MedicalHistoryPresentation> MedicalHistoryPresentations
        {
            get => _medicalHistoryPresentations;
            set
            {
                _medicalHistoryPresentations = value;
                OnPropertyChanged(nameof(MedicalHistoryPresentations));
            }
        }
        public PatientPresentation Patient
        {
            get => _patient;
        }

        public ICommand InitListCommand { get; set; }
        public ICommand RefreshListCommand { get; set; }
        public ICommand OpenAddWindowCommand { get;}
        public MedicalRecordViewModel(IMedicalHistoryService medicalHistoryService, MedicalRecordAddViewModel recordAddViewModel)
        {
            _medicalHistoryService = medicalHistoryService;
            _medicalRecordAddViewModel = recordAddViewModel;
            OpenAddWindowCommand = new RelayCommand(execute => OpenAddWindow());
            InitListCommand = new RelayCommand(async exec => await InitListAsync());
            RefreshListCommand = new RelayCommand(async exec => await InitListAsync());
        }

        public void InitializeParameters(object parameter)
        {
            if(parameter is PatientPresentation patient)
            {
                _patient = patient;
            }

            InitListCommand.Execute(null);
        }

        private async Task InitListAsync()
        {
            MedicalHistoryPresentations = await _medicalHistoryService.GetPatientHistoryAsync(Patient.PatId);
        }

        private void OpenAddWindow()
        {
            _medicalRecordAddViewModel.PatientId = Patient.PatId;
            var addWindow = new MedicalRecordAddWindow { DataContext = _medicalRecordAddViewModel };
            addWindow.ShowDialog();

            InitListCommand.Execute(null);
        }
    }
}
