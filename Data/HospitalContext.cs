using HealthHub.MVVM.Models.AuthInfo;
using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Other;
using HealthHub.MVVM.Models.Patients;
using HealthHub.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Data
{
    public partial class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }

        public HospitalContext(DbContextOptions<HospitalContext> options, ICurrentUserService currentUserService)
            : base(options)
        {
            CurrentUserService = currentUserService;
        }

        public ICurrentUserService CurrentUserService { get; set; }
        public virtual DbSet<AdminAuthInfo> AdminAuthInfos { get; set; }

        public virtual DbSet<AppointmentSchedule> AppointmentSchedules { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<DocAuthInfo> DocAuthInfos { get; set; }

        public virtual DbSet<Doctor> Doctors { get; set; }

        public virtual DbSet<DoctorSupervision> DoctorSupervisions { get; set; }

        public virtual DbSet<DoctorsSchedule> DoctorsSchedules { get; set; }

        public virtual DbSet<Family> Families { get; set; }

        public virtual DbSet<Hospital> Hospitals { get; set; }

        public virtual DbSet<Patient> Patients { get; set; }

        public virtual DbSet<Position> Positions { get; set; }

        public virtual DbSet<Recipe> Recipies { get; set; }

        public virtual DbSet<Role> Roles { get; set; }

        public virtual DbSet<SickLeave> SickLeavs { get; set; }

        public virtual DbSet<Specialty> Specialties { get; set; }

        public virtual DbSet<Visit> Visits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminAuthInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("adminAuthInfo_pkey");

                entity.ToTable("adminAuthInfo");

                entity.HasIndex(e => e.Login, "UniqLogin").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.Login)
                    .HasMaxLength(35)
                    .HasColumnName("login");
                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("password");
            });

            modelBuilder.Entity<AppointmentSchedule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("appointmentSchedule_pkey");

                entity.ToTable("appointmentSchedule");

                entity.HasIndex(e => e.DocId, "fki_d");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("true")
                    .HasColumnName("active");
                entity.Property(e => e.DocId).HasColumnName("doc_id");
                entity.Property(e => e.VisitDate).HasColumnName("visit_date");
                entity.Property(e => e.VisitTime)
                    .HasMaxLength(4)
                    .HasColumnName("visit_time");

                entity.HasOne(d => d.Doc).WithMany(p => p.AppointmentSchedules)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_doc");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.CityId).HasName("Cities_pkey");

                entity.ToTable("cities");

                entity.Property(e => e.CityId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("city_id");
                entity.Property(e => e.CityName)
                    .HasMaxLength(20)
                    .HasColumnName("city_name");
            });

            modelBuilder.Entity<DocAuthInfo>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("DocAuthInfo_pkey");

                entity.ToTable("docAuthInfo");

                entity.HasIndex(e => e.DocId, "fki_doc_id");

                entity.HasIndex(e => e.DocId, "uniqDocId").IsUnique();

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.DocId).HasColumnName("doc_id");
                entity.Property(e => e.Login)
                    .HasMaxLength(35)
                    .HasColumnName("login");
                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("password");
                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Doc).WithOne(p => p.DocAuthInfo)
                    .HasForeignKey<DocAuthInfo>(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_member_id");

                entity.HasOne(d => d.Role).WithMany(p => p.DocAuthInfos)
                    .HasPrincipalKey(p => p.Id)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_role_id");
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.HasKey(e => e.DocId).HasName("Doctors_pkey");

                entity.ToTable("doctors");

                entity.HasIndex(e => e.HospitalId, "fki_hospital_id");

                entity.HasIndex(e => e.PosId, "fki_pos_id");

                entity.HasIndex(e => e.SpecId, "fki_spec_id");

                entity.Property(e => e.DocId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("doc_id");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .HasColumnName("first_name");
                entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .HasColumnName("last_name");
                entity.Property(e => e.MiddleName)
                    .HasMaxLength(16)
                    .HasColumnName("middle_name");
                entity.Property(e => e.PosId).HasColumnName("pos_id");
                entity.Property(e => e.SpecId).HasColumnName("spec_id");

                entity.HasOne(d => d.Hospital).WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hospital_id");

                entity.HasOne(d => d.Pos).WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.PosId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pos_id");

                entity.HasOne(d => d.Spec).WithMany(p => p.Doctors)
                    .HasForeignKey(d => d.SpecId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("spec_id");
            });

            modelBuilder.Entity<DoctorSupervision>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("DoctorSupervisions_pkey");

                entity.ToTable("doctorSupervisions");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.Diagnosis).HasColumnName("diagnosis");
                entity.Property(e => e.DocId).HasColumnName("doc_id");
                entity.Property(e => e.ExamsFreq).HasColumnName("exams_freq");
                entity.Property(e => e.PatId).HasColumnName("pat_id");

                entity.HasOne(d => d.Doc).WithMany(p => p.DoctorSupervisions)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doc_id");

                entity.HasOne(d => d.Pat).WithMany(p => p.DoctorSupervisions)
                    .HasForeignKey(d => d.PatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pat_id");
            });

            modelBuilder.Entity<DoctorsSchedule>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("doctorsSchedules_pkey");

                entity.ToTable("doctorsSchedules");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");
                entity.Property(e => e.BaseDate).HasColumnName("base_date");
                entity.Property(e => e.DocId).HasColumnName("doc_id");
                entity.Property(e => e.EndTime)
                    .HasColumnType("time with time zone")
                    .HasColumnName("end_time");
                entity.Property(e => e.StartTime)
                    .HasColumnType("time with time zone")
                    .HasColumnName("start_time");
            });

            modelBuilder.Entity<Family>(entity =>
            {
                entity.HasKey(e => e.FamId).HasName("Families_pkey");

                entity.ToTable("families");

                entity.HasIndex(e => e.FamDocId, "fki_fam_doc_id");

                entity.HasIndex(e => e.HeadFamId, "fki_head_fam_id");

                entity.Property(e => e.FamId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("fam_id");
                entity.Property(e => e.Approved).HasColumnName("approved");
                entity.Property(e => e.FamDocId).HasColumnName("fam_doc_id");
                entity.Property(e => e.HeadFamId).HasColumnName("head_fam_id");

                entity.HasOne(d => d.FamDoc).WithMany(p => p.Families)
                    .HasForeignKey(d => d.FamDocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fam_doc_id");

                entity.HasOne(d => d.HeadFam).WithMany(p => p.Families)
                    .HasForeignKey(d => d.HeadFamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("head_fam_id");
            });

            modelBuilder.Entity<Hospital>(entity =>
            {
                entity.HasKey(e => e.HospitalId).HasName("Hospitals_pkey");

                entity.ToTable("hospitals");

                entity.Property(e => e.HospitalId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("hospital_id");
                entity.Property(e => e.Address)
                    .HasMaxLength(64)
                    .HasColumnName("address");
                entity.Property(e => e.CityId).HasColumnName("city_id");
                entity.Property(e => e.HospitalName)
                    .HasMaxLength(64)
                    .HasColumnName("hospital_name");

                entity.HasOne(d => d.City).WithMany(p => p.Hospitals)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_id");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.PatId).HasName("Patients_pkey");

                entity.ToTable("patients");

                entity.HasIndex(e => e.FamilyId, "fki_city_id");

                entity.HasIndex(e => e.Email, "uniquePhoneNumber").IsUnique();

                entity.Property(e => e.PatId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("pat_id");
                entity.Property(e => e.Address)
                    .HasMaxLength(20)
                    .HasColumnName("address");
                entity.Property(e => e.CityId).HasColumnName("city_id");
                entity.Property(e => e.DateOfBirthday).HasColumnName("date_of_birthday");
                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");
                entity.Property(e => e.FamilyId).HasColumnName("family_id");
                entity.Property(e => e.FirstName)
                    .HasMaxLength(16)
                    .HasColumnName("first_name");
                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .HasColumnName("gender");
                entity.Property(e => e.LastName)
                    .HasMaxLength(16)
                    .HasColumnName("last_name");
                entity.Property(e => e.Password)
                    .HasMaxLength(256)
                    .HasColumnName("password");
                entity.Property(e => e.RefreshToken)
                    .HasMaxLength(256)
                    .HasColumnName("refresh_token");

                entity.HasOne(d => d.City).WithMany(p => p.Patients)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("city_id");

                entity.HasOne(d => d.Family).WithMany(p => p.Patients)
                    .HasForeignKey(d => d.FamilyId)
                    .HasConstraintName("family_id");
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(e => e.PosId).HasName("Positions_pkey");

                entity.ToTable("positions");

                entity.Property(e => e.PosId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("pos_id");
                entity.Property(e => e.Post)
                    .HasMaxLength(20)
                    .HasColumnName("post");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.RecId).HasName("recipies_pkey");

                entity.ToTable("recipies");

                entity.Property(e => e.RecId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("rec_id");
                entity.Property(e => e.DocId).HasColumnName("doc_id");
                entity.Property(e => e.EndTerm).HasColumnName("end_term");
                entity.Property(e => e.MedicineName)
                    .HasMaxLength(50)
                    .HasColumnName("medicine_name");
                entity.Property(e => e.PatId).HasColumnName("pat_id");
                entity.Property(e => e.StartTerm).HasColumnName("start_term");

                entity.HasOne(d => d.Doc).WithMany(p => p.Recipies)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doc_id");

                entity.HasOne(d => d.Pat).WithMany(p => p.Recipies)
                    .HasForeignKey(d => d.PatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pat_id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Name).HasName("pk_role");

                entity.ToTable("roles");

                entity.HasIndex(e => e.Id, "unq_id").IsUnique();

                entity.Property(e => e.Name).HasMaxLength(30);
                entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
            });

            modelBuilder.Entity<SickLeave>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("SickLeavs_pkey");

                entity.ToTable("sickLeavs");

                entity.Property(e => e.Id)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("id");
                entity.Property(e => e.Diagnosis)
                    .HasMaxLength(50)
                    .HasColumnName("diagnosis");
                entity.Property(e => e.DocId).HasColumnName("doc_id");
                entity.Property(e => e.EndTerm).HasColumnName("end_term");
                entity.Property(e => e.HospitalId).HasColumnName("hospital_id");
                entity.Property(e => e.PatId).HasColumnName("pat_id");
                entity.Property(e => e.StartTerm).HasColumnName("start_term");

                entity.HasOne(d => d.Doc).WithMany(p => p.SickLeavs)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doc_id");

                entity.HasOne(d => d.Hospital).WithMany(p => p.SickLeavs)
                    .HasForeignKey(d => d.HospitalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("hospital_id");

                entity.HasOne(d => d.Pat).WithMany(p => p.SickLeavs)
                    .HasForeignKey(d => d.PatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pat_id");
            });

            modelBuilder.Entity<Specialty>(entity =>
            {
                entity.HasKey(e => e.SpecId).HasName("Specialties_pkey");

                entity.ToTable("specialties");

                entity.Property(e => e.SpecId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("spec_id");
                entity.Property(e => e.SpecName)
                    .HasColumnType("character varying")
                    .HasColumnName("spec_name");
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.HasKey(e => e.VisitId).HasName("Visits_pkey");

                entity.ToTable("visits");

                entity.HasIndex(e => e.PatId, "fki_pat_id");

                entity.Property(e => e.VisitId)
                    .UseIdentityAlwaysColumn()
                    .HasColumnName("visit_id");
                entity.Property(e => e.Active)
                    .IsRequired()
                    .HasDefaultValueSql("true")
                    .HasColumnName("active");
                entity.Property(e => e.DocId).HasColumnName("doc_id");
                entity.Property(e => e.PatId).HasColumnName("pat_id");
                entity.Property(e => e.VisitDate).HasColumnName("visit_date");
                entity.Property(e => e.VisitTime)
                    .HasColumnType("time with time zone")
                    .HasColumnName("visit_time");

                entity.HasOne(d => d.Doc).WithMany(p => p.Visits)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("doc_id");

                entity.HasOne(d => d.Pat).WithMany(p => p.Visits)
                    .HasForeignKey(d => d.PatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pat_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
