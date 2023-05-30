using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class AppointmentSchedule
    {
        public int Id { get; set; }

        public int DocId { get; set; }

        public string VisitTime { get; set; } = null!;

        public bool? Active { get; set; }

        public DateOnly VisitDate { get; set; }

        public virtual Doctor Doc { get; set; } = null!;
    }
}
