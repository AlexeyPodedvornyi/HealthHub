using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class Hospital
    {
        public int HospitalId { get; set; }

        public string Address { get; set; } = null!;

        public int CityId { get; set; }

        public string HospitalName { get; set; } = null!;

        public virtual City City { get; set; } = null!;

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();

        public virtual ICollection<SickLeave> SickLeavs { get; set; } = new List<SickLeave>();
    }
}
