using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public partial class Patient
    {
        public int PatId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateOnly DateOfBirthday { get; set; }

        public int? FamilyId { get; set; }

        public string Email { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string Address { get; set; } = null!;

        public int CityId { get; set; }
        
        [NotMapped]
        public string Password { get; set; } = null!;

        [NotMapped]
        public string? RefreshToken { get; set; }

        public string? MiddleName { get; set; }

        public virtual City City { get; set; } = null!;

        public virtual ICollection<DoctorSupervision> DoctorSupervisions { get; set; } = new List<DoctorSupervision>();

        public virtual ICollection<Family> Families { get; set; } = new List<Family>();

        public virtual Family? Family { get; set; }

        public virtual ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

        public virtual ICollection<PatientTreatment> PatientTreatments { get; set; } = new List<PatientTreatment>();

        public virtual ICollection<Recipe> Recipies { get; set; } = new List<Recipe>();

        public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();


        // Methods        
        public string GetFullName()
        {
            StringBuilder fullnameBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(FirstName))
            {
                fullnameBuilder.Append(FirstName);
            }

            if (!string.IsNullOrWhiteSpace(LastName))
            {
                if (fullnameBuilder.Length > 0)
                {
                    fullnameBuilder.Append(' ');
                }
                fullnameBuilder.Append(LastName);
            }

            if (!string.IsNullOrWhiteSpace(MiddleName))
            {
                if (fullnameBuilder.Length > 0)
                {
                    fullnameBuilder.Append(' ');
                }
                fullnameBuilder.Append(MiddleName);
            }

            return fullnameBuilder.ToString();
        }

    }
}
