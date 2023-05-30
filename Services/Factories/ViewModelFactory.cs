using HealthHub.MVVM.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public ViewModelFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModel
        {

            return _serviceProvider.GetService<TViewModel>()!;
        }
    }
}
