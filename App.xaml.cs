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
            services.AddSingleton<MenuViewModel>();
            services.AddSingleton<HomeViewModel>();
            services.AddTransient<ProfileViewModel>();
            services.AddSingleton<RecipeViewModel>();
            services.AddTransient<SickLeaveViewModel>();
            services.AddTransient<ReportViewModel>();
            services.AddSingleton<MedicalRecordViewModel>();
            services.AddSingleton<BindablePasswordBoxViewModel>();
            services.AddSingleton<AnimatedSidebarViewModel>();
            services.AddSingleton<MedicalRecordAddViewModel>();
            

            //Services
            services.AddSingleton<ICurrentUserService, CurrentUserService>();
            services.AddSingleton<INavigationService, NavigationService>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();          
            services.AddScoped<IDialogService, DialogService>();
            services.AddScoped<IPatientService, PatientService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IMedicalHistoryService, MedicalHistoryService>();
            services.AddScoped<IMedicalRecordService, MedicalRecordService>();
            services.AddScoped<IVisitService, VisitService>();
            services.AddScoped<IPatientTreatmentService, PatientTreatmentService>();
            services.AddScoped<IRecipeService, RecipeService>();
            services.AddScoped<ISickLeaveService, SickLeaveService>();
            services.AddScoped<IDoctorService, DoctorService>();

            // Data & Repositpries
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<AdminAuthInfoRepository>();
            services.AddScoped<DocAuthInfoRepository>();
            services.AddScoped<PatientRepository>();
            services.AddScoped<CityRepository>();
            services.AddScoped<MedicalHistoryRepository>();
            services.AddScoped<MedicalRecordRepository>();
            services.AddScoped<DoctorSupervisionRepository>();
            services.AddScoped<PatientTreatmentRepository>();
            services.AddScoped<VisitRepository>();
            services.AddScoped<DoctorRepository>();
            services.AddScoped<SpecialtyRepository>();
            services.AddScoped<RecipeRepository>();
            services.AddScoped<SickLeaveRepository>();

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
