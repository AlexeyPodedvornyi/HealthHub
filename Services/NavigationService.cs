using HealthHub.Core;
using HealthHub.MVVM.ViewModels;
using HealthHub.Services.Factories;
using HealthHub.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthHub.Services
{
    public class NavigationService : ObservableObject, INavigationService
    {
        private ViewModel _currentView;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IServiceProvider _serviceProvider;
        public ViewModel CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public NavigationService(IViewModelFactory viewModelFactory, IServiceProvider serviceProvider)
        {
            _viewModelFactory = viewModelFactory;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<T>() where T : ViewModel
        {
            var viewModel = _viewModelFactory.CreateViewModel<T>();
            CurrentView = viewModel;
        }

        public void NavigateTo<T>(object parameter) where T : ViewModel, IParameterizedNavigationViewModel
        {
            var viewModel = _viewModelFactory.CreateViewModel<T>();
            if (viewModel is IParameterizedNavigationViewModel parametricViewModel)
            {
                parametricViewModel.InitializeParameters(parameter);
            }
            CurrentView = viewModel;
        }

        public void OpenWindow<T>() where T : Window
        {
            var window = _serviceProvider.GetRequiredService<T>();
            window.Show();
        }

        public void CloseWindow()
        {
            var currentWindow = Application.Current.MainWindow;
            currentWindow.Close();
        }
    }
}
