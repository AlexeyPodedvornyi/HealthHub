using HealthHub.Helpers;
using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Helpers;
using HealthHub.MVVM.ViewModels.Presentations;
using HealthHub.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class RecipeViewModel : ViewModel, IParameterizedNavigationViewModel
    {
        private readonly IRecipeService _recipeService;
        private readonly IDialogService _dialogService;
        private readonly ICurrentUserService _currentUserService;
        private Patient _patient;
        private List<Recipe> _recipes;
        private Recipe _selectedListItem;
        private string _medicineName;
        private DateTime? _startTerm;
        private DateTime? _endTerm;

        public string MedicineName
        {
            get => _medicineName;
            set
            {
                _medicineName = value;
                OnPropertyChanged(nameof(MedicineName));
            }
        }
        public DateTime? StartTerm
        {
            get => _startTerm;
            set
            {
                _startTerm = value;
                OnPropertyChanged(nameof(StartTerm));
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
        public Patient Patient
        {
            get => _patient;
        }
        public List<Recipe> Recipes
        {
            get => _recipes;
            set
            {
                if (_recipes != value)
                {
                    _recipes = value;
                }
                OnPropertyChanged(nameof(Recipes));
            }
        }

        public Recipe SelectedListItem
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

        public ICommand InitListCommand { get; set; }
        public ICommand AddRecipeCommand { get; }


        public RecipeViewModel(IRecipeService recipeService, IDialogService dialogService, ICurrentUserService currentUserService)
        {
            _dialogService = dialogService;
            _recipeService = recipeService;
            _currentUserService = currentUserService;

            InitListCommand = new RelayCommand(async exec => await InitListAsync());
            AddRecipeCommand = new RelayCommand(async exec => await AddRecipeAsync());
        }

        public void InitializeParameters(object parameter)
        {
            if (parameter is Patient patient)
            {
                _patient = patient;
            }

            InitListCommand.Execute(null);
        }

        private async Task InitListAsync()
        {
            Recipes = await _recipeService.GetRecipesAsync(Patient.PatId);
        }

        private async Task AddRecipeAsync()
        {
            if(_currentUserService.CurrentUser is DocAuthInfo doc)
            {
                var isInputsValid = ValidateInputs();
                if (!isInputsValid)
                    return;

                var recipe = new Recipe
                {
                    DocId = doc.DocId,
                    PatId = _patient.PatId,
                    MedicineName = MedicineName,
                    StartTerm = Helpers.DateTimeConverter.ConvertToDateOnly(StartTerm),
                    EndTerm = Helpers.DateTimeConverter.ConvertToDateOnly(EndTerm)
                };

                await _recipeService.AddRecipeAsync(recipe);
                _dialogService.ShowInformation("Рецепт успішно створено!","Операція успішна");
                InitListCommand.Execute(null);
            }

        }
        private bool ValidateInputs()
        {
            if (string.IsNullOrEmpty(MedicineName))
            {
                _dialogService.ShowError("Поле \"Назва препарату\" не може бути порожнім", "Помилка даних");
                return false;
            }

            if (StartTerm == null || EndTerm == null)
            {
                _dialogService.ShowError("Поля з датами не можуть бути пустими", "Помилка даних");
                return false;
            }

            if (StartTerm.Value.Date < DateTime.Now.Date)
            {
                _dialogService.ShowError("У якості початкового терміну дії рецепту не може бути вказана минула дати", "Помилка даних");
                return false;
            }

            if (StartTerm >= EndTerm)
            {
                _dialogService.ShowError("Кінцевий термін дії не може бути менше за початковий", "Помилка даних");
                return false;
            }

            return true;
        }
    }
}
