using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public partial class DoctorsSchedule
    {
        public int Id { get; set; }

        public int DocId { get; set; }

        public DateOnly BaseDate { get; set; }

        public DateTimeOffset StartTime { get; set; }

        public DateTimeOffset EndTime { get; set; }

        public virtual Doctor Doc { get; set; } = null!;
    }
}
