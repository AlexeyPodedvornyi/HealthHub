using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public partial class DoctorsSchedule
    {
        [NotMapped]
        public int NotIncrementedId { get; set; }
    }
}
