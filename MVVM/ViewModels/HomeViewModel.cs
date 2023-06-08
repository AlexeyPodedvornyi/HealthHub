using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Models.Patients;
using HealthHub.MVVM.ViewModels.Presentations;
using HealthHub.Services.Factories;
using HealthHub.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class HomeViewModel: ViewModel
    {
        private readonly IPatientService _patientSearchService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private readonly IPatientViewModelFactory _patientViewModelFactory;
        private string? _searchRequest;
        private bool _isSearchMessageVisible;
        private List<PatientPresentation> _searchResult;

        public string? SearchRequest 
        { 
            get => _searchRequest;
            set
            {
                _searchRequest = value;
                OnPropertyChanged(nameof(SearchRequest));
            }
        }
        public List<PatientPresentation> SearchResult 
        {
            get => _searchResult;
            set
            {
                _searchResult = value;
                SearchResultChanged();
                OnPropertyChanged(nameof(SearchResult));
            }
        }
        public bool IsSearchMessageVisible 
        {
            get => _isSearchMessageVisible;
            set
            {
                _isSearchMessageVisible = value;
                OnPropertyChanged(nameof(IsSearchMessageVisible));
            }
        }

        public ICommand SearchCommand { get; }
        public ICommand OpenMedicalRecordCommand { get; }
        public ICommand WriteRecipeCommand { get; }
        public ICommand WriteSickLeaveCommand { get; }


        public HomeViewModel(IPatientService patientSearchService, IDialogService dialogService, IPatientViewModelFactory patientViewModelFactory, INavigationService navigationService) 
        {
            _patientSearchService = patientSearchService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            _patientViewModelFactory = patientViewModelFactory;

            SearchCommand = new RelayCommand(async execute => await HandleSearchQuerryAsync());
            OpenMedicalRecordCommand = new RelayCommand(OpenMedicalRecord);
            IsSearchMessageVisible = false;
        }

        private async Task HandleSearchQuerryAsync()
        {
            if (string.IsNullOrEmpty(SearchRequest))
            {
                _dialogService.ShowError("Пошуковий запит не може бути порожнім!", "Помилка введення даних");
                return;
            }

            var result = await _patientSearchService.SearchAsync(SearchRequest);
            SearchResult = new List<PatientPresentation>(
                result.Select(patient => _patientViewModelFactory.Create(patient)));            
        }

        private void SearchResultChanged()
        {
            if (SearchResult == null || SearchResult.Count == 0)
            {
                IsSearchMessageVisible = true;
            }
            else
            {
                IsSearchMessageVisible = false;
            }
                     
        }

        private void OpenContextMenu(object parameter)
        {
            var selectedPatient = parameter as PatientPresentation;

            
        }

        private void OpenMedicalRecord(object parameter)
        {
            var selectedPatient = parameter as PatientPresentation;
            if(selectedPatient == null)
            {
                _dialogService.ShowError("Обраного пацієнта не існує! Виконайте пошук знову та спробуйте ще раз.", "Помилка читання даних");
                return;
            }

            _navigationService.NavigateTo<MedicalRecordViewModel>(selectedPatient);
        }
    }
}
