using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.AuthInfo
{
    [Serializable]
    public class DoctorAuthInfo : IUserAuthInfo
    {
        public string Login { get; private set; }
        public string Password { get; private set; }
        public int Role { get; private set; }

        public DoctorAuthInfo(string login, string password, int role)
        {
            Login = login;
            Password = password;
            Role = role;
        }

    }
}
