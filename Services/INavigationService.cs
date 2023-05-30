using HealthHub.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HealthHub.Services
{
    public interface INavigationService
    {
        ViewModel CurrentView { get; }
        void NavigateTo<T>() where T : ViewModel;
        void OpenWindow<T>() where T : Window;
        void CloseWindow();
    }
}
