using HealthHub.Core;
using HealthHub.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModel
{
    class AuthViewModel : ObservableObject, IViewModel
    {
        //Properties
        public ICommand MoveWindowCommand { get; }
        public ICommand CloseAppCommand { get; }

        //Constructors
        public AuthViewModel()
        {
            MoveWindowCommand = new MoveWindowCommand();
            CloseAppCommand = new RelayCommand(execute => Application.Current.Shutdown());
        }

        
    }
}
