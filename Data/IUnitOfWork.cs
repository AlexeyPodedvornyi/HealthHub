using HealthHub.Data.Repositories.AuthInfo;
using HealthHub.Data.Repositories.Doctors;
using HealthHub.Data.Repositories.Other;
using HealthHub.Data.Repositories.Patients;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data
{
    public interface IUnitOfWork
    {
        AdminAuthInfoRepository AdminAuthInfoRepository { get; }
        DocAuthInfoRepository DocAuthInfoRepository { get;  }
        PatientRepository PatientRepository { get; }
        CityRepository CityRepository { get; }
        PatientTreatmentRepository PatientTreatmentRepository { get; }
        MedicalRecordRepository MedicalRecordRepository { get; }
        MedicalHistoryRepository MedicalHistoryRepository { get; }
        VisitRepository VisitRepository { get; }
        DoctorSupervisionRepository DoctorSupervisionRepository { get; }
        DoctorRepository DoctorRepository { get; }
        SpecialtyRepository SpecialtyRepository { get; }
        RecipeRepository RecipeRepository { get; }
        SickLeaveRepository SickLeaveRepository { get; }
        DbContext DbContext
        {
            get;
        }
        void SetConnectionString(string connectionString);
        void Commit();
        Task SaveChangesAsync();
        void Dispose();
    }
}
