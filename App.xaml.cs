using HealthHub.MVVM.ViewModel;
using HealthHub.MVVM.View;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HealthHub.Services.Factories;
using HealthHub.Services;

namespace HealthHub
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {

            IServiceCollection services = new ServiceCollection();
            //services.AddSingleton<MVVM.View.AuthWindow>(provider => new MVVM.View.AuthWindow{ DataContext = provider.GetService<AuthViewModel>()});
            services.AddTransient<AuthViewModel>();
            services.AddTransient<BindablePasswordBoxViewModel>();
            services.AddTransient<IUserFactory, UserFactory>();
            services.AddTransient<IConnectionProvider, ConnectionProvider>();
            services.AddTransient<IConnectionProviderFactory, ConnectionProviderFactory>();

         //   services.AddTransient<IUserFactory, AdminFactory>();
         //   services.AddTransient<IUserFactory, DoctorFactory>();

            
            services.AddSingleton<IUserService,UserService>();


            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var startWindow = new MVVM.View.AuthWindow(_serviceProvider.GetService<IUserService>()!)
            {
                DataContext = _serviceProvider.GetService<AuthViewModel>()
            };

            startWindow.Show();
        }
    }
}
