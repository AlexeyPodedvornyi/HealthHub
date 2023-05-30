using HealthHub.MVVM.Models.Doctors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.AuthInfo
{
    public class DocAuthInfo : IUserAuthInfo
    {
        public int Id { get; set; }

        public int DocId { get; set; }

        public string Login { get; set; } = null!;

        public string Password { get; set; } = null!;

        public int RoleId { get; set; }

        public virtual Doctor Doc { get; set; } = null!;

        public virtual Role Role { get; set; } = null!;
    }
}
