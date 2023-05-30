using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class City
    {
        public int CityId { get; set; }

        public string CityName { get; set; } = null!;

        public virtual ICollection<Hospital> Hospitals { get; set; } = new List<Hospital>();

        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
