using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.ViewModels
{
    public interface IParameterizedNavigationViewModel
    {
        void InitializeParameters(object parameter);
    }
}
