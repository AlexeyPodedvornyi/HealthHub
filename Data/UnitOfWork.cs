using HealthHub.Data.Repositories.AuthInfo;
using HealthHub.Data.Repositories.Doctors;
using HealthHub.Data.Repositories.Other;
using HealthHub.Data.Repositories.Patients;
using HealthHub.MVVM.Models.AuthInfo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        public AdminAuthInfoRepository AdminAuthInfoRepository { get; private set; }
        public DocAuthInfoRepository DocAuthInfoRepository { get; private set; }
        public PatientRepository PatientRepository { get; private set; }
        public CityRepository CityRepository { get; private set; }
        public PatientTreatmentRepository PatientTreatmentRepository { get; private set; }
        public MedicalRecordRepository MedicalRecordRepository { get; private set; }
        public MedicalHistoryRepository MedicalHistoryRepository { get; private set; }
        public VisitRepository VisitRepository { get; private set; }
        public DoctorSupervisionRepository DoctorSupervisionRepository { get; private set; }
        public DoctorRepository DoctorRepository { get; private set; }
        public SpecialtyRepository SpecialtyRepository { get; private set; }
        public RecipeRepository RecipeRepository { get; private set; }
        public SickLeaveRepository SickLeaveRepository { get; private set; }
        public DoctorsScheduleRepository DoctorsScheduleRepository { get; private set; }
        public AppointmentScheduleRepository AppointmentScheduleRepository { get; private set; }


        public UnitOfWork(DbContext dbContext, AdminAuthInfoRepository adminAuthInfoRepository, DocAuthInfoRepository docAuthInfoRepository, PatientRepository patientRepository,
            CityRepository cityRepository, PatientTreatmentRepository patientTreatmentRepository, MedicalRecordRepository medicalRecordRepository, MedicalHistoryRepository medicalHistoryRepository,
            VisitRepository visitRepository, DoctorSupervisionRepository doctorSupervisionRepository, DoctorRepository doctorRepository, SpecialtyRepository specialtyRepository,
            RecipeRepository recipeRepository, SickLeaveRepository sickLeaveRepository, DoctorsScheduleRepository doctorsScheduleRepository, AppointmentScheduleRepository appointmentScheduleRepository)
        {
            _dbContext = dbContext;
            AdminAuthInfoRepository = adminAuthInfoRepository;
            DocAuthInfoRepository = docAuthInfoRepository;
            PatientRepository = patientRepository;
            CityRepository = cityRepository;
            PatientTreatmentRepository = patientTreatmentRepository;
            MedicalRecordRepository = medicalRecordRepository;
            MedicalHistoryRepository = medicalHistoryRepository;
            DoctorSupervisionRepository = doctorSupervisionRepository;
            VisitRepository = visitRepository;
            DoctorRepository = doctorRepository;
            SpecialtyRepository = specialtyRepository;
            RecipeRepository = recipeRepository;
            SickLeaveRepository = sickLeaveRepository;
            DoctorsScheduleRepository = doctorsScheduleRepository;
            AppointmentScheduleRepository = appointmentScheduleRepository;
        }

        public void SetConnectionString(string connectionString)
        {
            _dbContext.Database.SetConnectionString(connectionString);
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
        }
    }
}
