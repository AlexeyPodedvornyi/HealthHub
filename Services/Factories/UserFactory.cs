using HealthHub.MVVM.Models.AuthInfo;
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
        public IUserAuthInfo? Create(IDataRecord record, string role)
        {
            return role switch
            {
                "doctor" => new DoctorAuthInfo(record.GetString(record.GetOrdinal("login")), record.GetString(record.GetOrdinal("password")), record.GetInt32(record.GetOrdinal("role"))),
                "admin" => new AdminAuthInfo(record.GetString(record.GetOrdinal("login")), record.GetString(record.GetOrdinal("password"))),
                _ => null,
            };
        }

        public IUserAuthInfo? CreateUser(IDataRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
