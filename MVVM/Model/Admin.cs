using HealthHub.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Model
{
    [Serializable]
    public class Admin : IUser
    {
        public string Login { get; set; }
        public string Password { get ; set; }

        public Admin(string login, string password) 
        {
            Login = login;   
            Password = password;
        }

    }
}
