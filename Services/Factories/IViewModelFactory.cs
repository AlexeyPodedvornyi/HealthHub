using HealthHub.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public interface IViewModelFactory
    {
        TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModel;
    }
}
