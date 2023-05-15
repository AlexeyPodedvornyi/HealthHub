using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.AuthInfo
{
    [Serializable]
    public class AdminAuthInfo : IUserAuthInfo
    {
        public string Login { get; private set; }
        public string Password { get; private set; }

        public AdminAuthInfo(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
