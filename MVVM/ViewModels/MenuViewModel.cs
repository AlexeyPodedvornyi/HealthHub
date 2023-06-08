using HealthHub.Data;
using HealthHub.MVVM.Commands;
using HealthHub.MVVM.ViewModels.Controls;
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

        //Commands
        public ICommand MoveWindowCommand { get; }
        public ICommand CloseAppCommand { get; }

        //Navigation commands
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateProfileCommand { get; }
        public ICommand NavigateRecipeCommand { get; }
        public ICommand NavigateSickLeaveCommand { get; }
        public ICommand NavigateReportCommand { get; }
       
        //Constructors
        public MenuViewModel(INavigationService navigationService, AnimatedSidebarViewModel animatedSidebarViewModel)
        {
            //Injections
            _navigation = navigationService;
            AnimatedSidebarViewModel = animatedSidebarViewModel;

            //Navigation commands
            NavigateHomeCommand = new RelayCommand(execute => Navigation.NavigateTo<HomeViewModel>());
            NavigateProfileCommand = new RelayCommand(execute => Navigation.NavigateTo<ProfileViewModel>());
            NavigateRecipeCommand = new RelayCommand(execute => Navigation.NavigateTo<RecipeViewModel>());
            NavigateSickLeaveCommand = new RelayCommand(execute => Navigation.NavigateTo<SickLeaveViewModel>());
            NavigateReportCommand = new RelayCommand(execute => Navigation.NavigateTo<ReportViewModel>());

            //Other commads
            MoveWindowCommand = new MoveWindowCommand();
            CloseAppCommand = new RelayCommand(execute => Application.Current.Shutdown());

            //Other code
            NavigateHomeCommand.Execute(null);
        }
    }
}
