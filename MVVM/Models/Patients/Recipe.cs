using HealthHub.MVVM.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public class Recipe
    {
        public int RecId { get; set; }

        public int DocId { get; set; }

        public int PatId { get; set; }

        public string MedicineName { get; set; } = null!;

        public DateOnly EndTerm { get; set; }

        public DateOnly StartTerm { get; set; }

        public virtual Doctor Doc { get; set; } = null!;

        public virtual Patient Pat { get; set; } = null!;
    }
}
