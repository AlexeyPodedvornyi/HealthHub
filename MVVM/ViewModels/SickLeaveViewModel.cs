using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.ViewModels
{
    public class SickLeaveViewModel : ViewModel, IParameterizedNavigationViewModel
    {
        public SickLeaveViewModel()
        {
            
        }

        public void InitializeParameters(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
