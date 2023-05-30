using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Other;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public class Patient
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

        public string Password { get; set; } = null!;

        public string? RefreshToken { get; set; }

        public virtual City City { get; set; } = null!;

        public virtual ICollection<DoctorSupervision> DoctorSupervisions { get; set; } = new List<DoctorSupervision>();

        public virtual ICollection<Family> Families { get; set; } = new List<Family>();

        public virtual Family? Family { get; set; }

        public virtual ICollection<Recipe> Recipies { get; set; } = new List<Recipe>();

        public virtual ICollection<SickLeave> SickLeavs { get; set; } = new List<SickLeave>();

        public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();
    }
}
