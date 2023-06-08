using HealthHub.MVVM.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public partial class MedicalRecord
    {
        public int Id { get; set; }

        public int PatId { get; set; }

        public virtual ICollection<MedicalHistory> MedicalHistories { get; set; } = new List<MedicalHistory>();

        public virtual Patient Pat { get; set; } = null!;
    }
}
