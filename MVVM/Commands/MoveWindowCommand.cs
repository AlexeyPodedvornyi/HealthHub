using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace HealthHub.MVVM.Commands
{
    public class MoveWindowCommand : ICommand
    {
         public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            if (parameter is Window window && window is not null)
            {
                window.DragMove();
            }
        }


        public event EventHandler? CanExecuteChanged;
    }
}
