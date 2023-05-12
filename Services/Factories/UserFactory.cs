using HealthHub.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public class UserFactory : IUserFactory
    {
        public IUser? Create(IDataRecord record, string role)
        {
            return role switch
            {
                "doctor" => new Doctor(record.GetString(record.GetOrdinal("login")), record.GetString(record.GetOrdinal("password")), record.GetString(record.GetOrdinal("role"))),
                "admin" => new Admin(record.GetString(record.GetOrdinal("login")), record.GetString(record.GetOrdinal("password"))),
                _ => null,
            };
        }

        public IUser? CreateUser(IDataRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
