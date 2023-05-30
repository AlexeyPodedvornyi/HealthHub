using HealthHub.Core;
using HealthHub.Helpers;
using HealthHub.MVVM.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace HealthHub.MVVM.ViewModels
{
    public class BindablePasswordBoxViewModel: ViewModel
    {
        //Fields
        private SecureString _password;
        private bool _isPasswordTooShort;

        //Properties
        public SecureString Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public bool IsPasswordTooShort
        {
            get { return _isPasswordTooShort; }
            set
            {
                _isPasswordTooShort = value;
                OnPropertyChanged(nameof(IsPasswordTooShort));
            }
        }

        //Commands (also Properties)
        public ICommand PasswordChangedCommand { get; set; }

        //Constructors
        public BindablePasswordBoxViewModel()
        {
            IsPasswordTooShort = true;
            PasswordChangedCommand = new RelayCommand(PasswordHandle);
        }

        //public Methods


        //private Methods
        private void PasswordHandle(object param)
        {
            if (param is PasswordBox passwordBox)
            {
                Password = passwordBox.SecurePassword;
                if (Password.Length == 0)
                {
                    IsPasswordTooShort = true;
                }
                else
                {
                    IsPasswordTooShort = false;
                }
            }
        }
    }
}
