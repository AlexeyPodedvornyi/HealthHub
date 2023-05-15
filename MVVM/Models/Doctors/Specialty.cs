using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class Specialty
    {
        public string Spec_Id { get; set; }
        public string Spec_Name { get; set; }

        public Specialty(string spec_Id, string spec_Name)
        {
            Spec_Id = spec_Id;
            Spec_Name = spec_Name;
        }
    }
}
