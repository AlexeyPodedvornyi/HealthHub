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
    public class HomeViewModel : ViewModel
    {
        private readonly IPatientService _patientSearchService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private string? _searchRequest;
        private bool _isSearchMessageVisible;
        private List<Patient> _searchResult;

        public string? SearchRequest
        {
            get => _searchRequest;
            set
            {
                _searchRequest = value;
                OnPropertyChanged(nameof(SearchRequest));
            }
        }

        public List<Patient> SearchResult
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
        public ICommand OpenRecipeCommand { get; }
        public ICommand OpenSickLeaveCommand { get; }
        public ICommand WriteRecipeCommand { get; }
        public ICommand WriteSickLeaveCommand { get; }


        public HomeViewModel(IPatientService patientSearchService, IDialogService dialogService, INavigationService navigationService)
        {
            _patientSearchService = patientSearchService;
            _dialogService = dialogService;
            _navigationService = navigationService;

            SearchCommand = new RelayCommand(async execute => await HandleSearchQuerryAsync());
            OpenMedicalRecordCommand = new RelayCommand(OpenMedicalRecord);
            OpenRecipeCommand = new RelayCommand(OpenRecipe);
            OpenSickLeaveCommand = new RelayCommand(OpenSickLeave);

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
            SearchResult = result;
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

        private void OpenMedicalRecord(object parameter)
        {
            var selectedPatient = parameter as Patient;
            if (selectedPatient == null)
            {
                _dialogService.ShowError("Обраного пацієнта не існує! Виконайте пошук знову та спробуйте ще раз.", "Помилка читання даних");
                return;
            }

            _navigationService.NavigateTo<MedicalRecordViewModel>(selectedPatient);
        }

        private void OpenRecipe(object parameter)
        {
            var selectedPatient = parameter as Patient;
            if (selectedPatient == null)
            {
                _dialogService.ShowError("Обраного пацієнта не існує! Виконайте пошук знову та спробуйте ще раз.", "Помилка читання даних");
                return;
            }

            _navigationService.NavigateTo<RecipeViewModel>(selectedPatient);
        }

        private void OpenSickLeave(object parameter)
        {
            var selectedPatient = parameter as Patient;
            if (selectedPatient == null)
            {
                _dialogService.ShowError("Обраного пацієнта не існує! Виконайте пошук знову та спробуйте ще раз.", "Помилка читання даних");
                return;
            }

            _navigationService.NavigateTo<SickLeaveViewModel>(selectedPatient);
        }
    }
}
