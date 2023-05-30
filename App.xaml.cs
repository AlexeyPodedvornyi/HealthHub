using HealthHub.MVVM.ViewModels;
using HealthHub.MVVM.Views;
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
using HealthHub.Data;
using Microsoft.EntityFrameworkCore;
using HealthHub.Data.Repositories.AuthInfo;
using HealthHub.MVVM.Models.AuthInfo;
using System.ComponentModel;

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

            // Windows & Views
            services.AddSingleton<AuthWindow>(provider => new AuthWindow{ DataContext = provider.GetService<AuthViewModel>()});
            services.AddTransient<MenuWindow>();

            // ViewModels
            services.AddTransient<AuthViewModel>();
            services.AddTransient<MenuViewModel>();
            services.AddSingleton<BindablePasswordBoxViewModel>();

            //Services
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();          
            services.AddTransient<IDialogService, DialogService>();

            // Data & Repositpries
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<AdminAuthInfoRepository>();
            services.AddTransient<DocAuthInfoRepository>();

            services.AddTransient<DbContext, HospitalContext>(provider => provider.GetRequiredService<HospitalContextFactory>().CreateDbContext(null));

            // Factories
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddScoped<HospitalContextFactory>();

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var startWindow = _serviceProvider.GetRequiredService<MenuWindow>();
            startWindow.Show();
        }
    }
}
