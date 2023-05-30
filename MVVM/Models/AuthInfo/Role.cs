using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.AuthInfo
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<DocAuthInfo> DocAuthInfos { get; set; } = new List<DocAuthInfo>();

    }
}
