using HealthHub.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthHub.Services.Interfaces
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }

        void NavigateTo<T>() where T : ViewModel;
        void NavigateTo<T>(object parameter) where T : ViewModel, IParameterizedNavigationViewModel;
        void OpenWindow<T>() where T : Window;
        void CloseWindow();
    }
}
