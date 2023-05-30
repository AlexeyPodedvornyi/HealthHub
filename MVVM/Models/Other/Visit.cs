using HealthHub.MVVM.Models.Doctors;
using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class Visit
    {
        public int VisitId { get; set; }

        public int PatId { get; set; }

        public int DocId { get; set; }

        public DateOnly VisitDate { get; set; }

        public bool? Active { get; set; }

        public DateTimeOffset VisitTime { get; set; }

        public virtual Doctor Doc { get; set; } = null!;

        public virtual Patient Pat { get; set; } = null!;
    }
}
