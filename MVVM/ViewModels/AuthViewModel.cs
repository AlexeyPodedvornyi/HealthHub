using HealthHub.Core;
using HealthHub.MVVM.Commands;
using HealthHub.MVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security;
using HealthHub.Helpers;
using HealthHub.Services.Interfaces;
using HealthHub.MVVM.ViewModels.Controls;

namespace HealthHub.MVVM.ViewModels
{
    class AuthViewModel : ViewModel
    {
        //Fields
        private INavigationService _navigationService;
        private readonly IAuthorizationService _authorizationService;
        private readonly IDialogService _dialogService;     

        //Properties
        public string? Login { get; set; }
        public SecureString? Password => PasswordBoxViewModel.Password;
        public BindablePasswordBoxViewModel PasswordBoxViewModel { get; private set; }

        public INavigationService NavigationService
        {
            get => _navigationService;
            set
            {
                _navigationService = value;
                OnPropertyChanged();
            }
        }
        public ICommand MoveWindowCommand { get; }
        public ICommand CloseAppCommand { get; }
        public ICommand OpenMainMenuCommand { get; }
        public ICommand SignInCommand { get; }

        //Constructors
        public AuthViewModel(INavigationService navService, IAuthorizationService authorizationService, IDialogService dialogService, 
            BindablePasswordBoxViewModel bindablePasswordBoxViewModel)
        {
            _navigationService = navService;
            _authorizationService = authorizationService;
            _dialogService = dialogService;
            PasswordBoxViewModel = bindablePasswordBoxViewModel;

            MoveWindowCommand = new MoveWindowCommand();
            CloseAppCommand = new RelayCommand(execute => Application.Current.Shutdown());
            OpenMainMenuCommand = new RelayCommand(execute => OpenMainMenu());
            SignInCommand = new RelayCommand(async execute => await AuthorizeUser());
        }

        private void OpenMainMenu()
        {          
            _navigationService.OpenWindow<MenuWindow>();
            _navigationService.CloseWindow();
        }
        private async Task AuthorizeUser()
        {
            string? passwordUnsecureString = Password?.ToUnsecureString();
            if ((Login == string.Empty || passwordUnsecureString == string.Empty) || (Login == null || passwordUnsecureString == null))
            {
                _dialogService.ShowError("Поля 'Логін' та 'Пароль' не можуть бути порожніми!", "\nПомилка авторизації ");
                return;
            }

            var isAccessGranted = await _authorizationService.IsAccessGrantedAsync(Login, passwordUnsecureString);
            if (isAccessGranted)
            {
                _dialogService.ShowInformation("Ласкаво просимо", "\nАвторизація успішна ");
                
                OpenMainMenuCommand.Execute(null);
            }
            else
            {
                _dialogService.ShowError("Користувача з зазначеним 'Логіном' та 'Паролем' не знайдено. Перевірте правильність введених даних", 
                    "\nПомилка авторизації ");
            }
        }
        
    }
}
