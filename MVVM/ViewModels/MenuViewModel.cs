using HealthHub.Data;
using HealthHub.MVVM.Commands;
using HealthHub.Services;
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
        private bool _isSidebarExpanded;
        private INavigationService _navigation;

        //Properties
        public bool IsSidebarExpanded
        {
            get => _isSidebarExpanded;
            set
            {
                if (_isSidebarExpanded != value)
                {
                    _isSidebarExpanded = value;
                    OnPropertyChanged(nameof(IsSidebarExpanded));
                }
            }
        }
        public INavigationService Navigation
        {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged(nameof(Navigation));
            }
        }


        //Commands
        public ICommand MoveWindowCommand { get; }
        public ICommand CloseAppCommand { get; }
        public ICommand SidebarMouseEnterCommand { get; }
        public ICommand SidebarMouseLeaveCommand { get; }
        public ICommand CheckNavigationButtonCommand { get; }

        //Navigation commands
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateProfileCommand { get; }
        public ICommand NavigateRecipeCommand { get; }
        public ICommand NavigateSickLeaveCommand { get; }
        public ICommand NavigateReportCommand { get; }
       
        //Constructors
        public MenuViewModel(INavigationService navigationService)
        {
            Navigation = navigationService;

            //Navigation commands
            NavigateHomeCommand = new RelayCommand(execute => Navigation.NavigateTo<HomeViewModel>());
            NavigateProfileCommand = new RelayCommand(execute => Navigation.NavigateTo<ProfileViewModel>());
            NavigateRecipeCommand = new RelayCommand(execute => Navigation.NavigateTo<RecipeViewModel>());
            NavigateSickLeaveCommand = new RelayCommand(execute => Navigation.NavigateTo<SickLeaveViewModel>());
            NavigateReportCommand = new RelayCommand(execute => Navigation.NavigateTo<ReportViewModel>());

            //Other commads
            MoveWindowCommand = new MoveWindowCommand();
            CloseAppCommand = new RelayCommand(execute => Application.Current.Shutdown());
            SidebarMouseEnterCommand = new RelayCommand(execute => OnSidebarMouseEnter());
            SidebarMouseLeaveCommand = new RelayCommand(execute => OnSidebarMouseLeave());
            CheckNavigationButtonCommand = new RelayCommand(CheckNavigationButtonHandler);
        }

        //Methods
        private void OnSidebarMouseEnter()
        {
            IsSidebarExpanded = true;
        }

        private void OnSidebarMouseLeave()
        {
            IsSidebarExpanded = false;
        }

        private void CheckNavigationButtonHandler(object sender)
        {
            //if(sender is RadioButton radioButton)
            //{
            //    if (ActivenNavigationButton == radioButton) 
            //        return;

            //    if(ActivenNavigationButton != null)
            //    {
            //        MessageBox.Show(ActivenNavigationButton.Name + "\n" + radioButton.Name);
            //        ActivenNavigationButton.IsChecked = false;
            //        radioButton.IsChecked = true;
            //        ActivenNavigationButton = radioButton;
                    
            //    }
            //    else
            //    {
            //        MessageBox.Show(ActivenNavigationButton?.Name + "\n" + radioButton.Name);

            //        radioButton.IsChecked = true;
            //        ActivenNavigationButton = radioButton;
            //    }
            //}
        }
    }
}
