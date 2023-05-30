using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class Family
    {
        public int FamId { get; set; }

        public int FamDocId { get; set; }

        public int HeadFamId { get; set; }

        public bool Approved { get; set; }

        public virtual Doctor FamDoc { get; set; } = null!;

        public virtual Patient HeadFam { get; set; } = null!;

        public virtual ICollection<Patient> Patients { get; set; } = new List<Patient>();
    }
}
