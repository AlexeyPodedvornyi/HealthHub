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
using HealthHub.Data.Repositories.Patients;
using HealthHub.Data.Repositories.Other;
using HealthHub.Data.Repositories.Doctors;
using HealthHub.Services.Interfaces;
using HealthHub.MVVM.ViewModels.Controls;

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
            services.AddTransient<MenuWindow>(provider => new MenuWindow { DataContext = provider.GetService<MenuViewModel>()});

            // ViewModels
            services.AddTransient<AuthViewModel>();
            services.AddTransient<MenuViewModel>();
            services.AddTransient<HomeViewModel>();
            services.AddTransient<ProfileViewModel>();
            services.AddTransient<RecipeViewModel>();
            services.AddTransient<SickLeaveViewModel>();
            services.AddTransient<ReportViewModel>();
            services.AddTransient<MedicalRecordViewModel>();
            services.AddSingleton<BindablePasswordBoxViewModel>();
            services.AddSingleton<AnimatedSidebarViewModel>();
            

            //Services
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();          
            services.AddTransient<IDialogService, DialogService>();
            services.AddTransient<IPatientService, PatientService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IMedicalHistoryService, MedicalHistoryService>();

            // Data & Repositpries
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<AdminAuthInfoRepository>();
            services.AddTransient<DocAuthInfoRepository>();
            services.AddTransient<PatientRepository>();
            services.AddTransient<CityRepository>();
            services.AddTransient<MedicalHistoryRepository>();
            services.AddTransient<MedicalRecordRepository>();
            services.AddTransient<DoctorSupervisionRepository>();
            services.AddTransient<PatientTreatmentRepository>();
            services.AddTransient<VisitRepository>();
            services.AddTransient<DoctorRepository>();
            services.AddTransient<SpecialtyRepository>();

            services.AddScoped<DbContext, HospitalContext>(provider => provider.GetRequiredService<HospitalContextFactory>().CreateDbContext(null));

            // Factories
            services.AddSingleton<IViewModelFactory, ViewModelFactory>();
            services.AddScoped<IPatientViewModelFactory, PatientViewModelFactory>();
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
