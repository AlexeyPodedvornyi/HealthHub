using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services.Factories
{
    public class ConnectionProviderFactory : IConnectionProviderFactory
    {
        public IConnectionProvider? Create(string role)
        {
            return role switch
            {
                "doctor" => new ConnectionProvider(ConfigurationManager.ConnectionStrings["doctorRole"].ConnectionString),
                "admin" => new ConnectionProvider(ConfigurationManager.ConnectionStrings["adminRole"].ConnectionString),
                "unauthorized" => new ConnectionProvider(ConfigurationManager.ConnectionStrings["unauthorizedRole"].ConnectionString),
                _ => null
            };
        }
    }
}
