using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public partial class Doctor
    {
        public string FullName { get => $"{LastName} {FirstName} {MiddleName}"; }

    }
}
