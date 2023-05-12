using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public interface IConnectionProvider
    {
        string? ConnectioOwner { get; set; }
        IDbConnection GetConnection();
        
    }
}
