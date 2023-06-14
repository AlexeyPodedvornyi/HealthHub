using HealthHub.Data;
using HealthHub.MVVM.Commands;
using HealthHub.MVVM.ViewModels.Controls;
using HealthHub.MVVM.Views;
using HealthHub.Services;
using HealthHub.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class MenuViewModel : ViewModel
    {
        //Fields
        private INavigationService _navigation;
        private ICurrentUserService _currentUserService;
        private bool _isScheduleVisible;

        //Properties
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }
        public AnimatedSidebarViewModel AnimatedSidebarViewModel{ get; }
        public bool IsScheduleVisible
        {
            get => _isScheduleVisible; 
            private set
            {
                _isScheduleVisible = value;
                OnPropertyChanged(nameof(IsScheduleVisible));
            } 
        } 

        //Commands
        public ICommand MoveWindowCommand { get; }
        public ICommand CloseAppCommand { get; }

        //Navigation commands
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateProfileCommand { get; }
        public ICommand NavigateRecipeCommand { get; }
        public ICommand NavigateSickLeaveCommand { get; }
        public ICommand NavigateDoctorsScheduleCommand { get; }
       
        //Constructors
        public MenuViewModel(INavigationService navigationService, AnimatedSidebarViewModel animatedSidebarViewModel, ICurrentUserService currentUserService)
        {
            //Injections
            _navigation = navigationService;
            AnimatedSidebarViewModel = animatedSidebarViewModel;
            _currentUserService = currentUserService;

            //Navigation commands
            NavigateHomeCommand = new RelayCommand(execute => Navigation.NavigateTo<HomeViewModel>());
            NavigateProfileCommand = new RelayCommand(execute => Navigation.NavigateTo<ProfileViewModel>());
            NavigateRecipeCommand = new RelayCommand(execute => Navigation.NavigateTo<RecipeViewModel>());
            NavigateSickLeaveCommand = new RelayCommand(execute => Navigation.NavigateTo<SickLeaveViewModel>());
            NavigateDoctorsScheduleCommand = new RelayCommand(execute => Navigation.NavigateTo<DoctorsScheduleViewModel>());

            //Other commads
            MoveWindowCommand = new MoveWindowCommand();
            CloseAppCommand = new RelayCommand(execute => Application.Current.Shutdown());

            //Other code
            NavigateHomeCommand.Execute(null);

            if(_currentUserService.CurrentRole == CurrentUserService.UserRole.DepartmentHead)
                IsScheduleVisible = true;
            else 
                IsScheduleVisible = false;
        }
    }
}
