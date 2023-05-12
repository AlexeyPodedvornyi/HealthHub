using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly string _connectionString;

        public string? ConnectioOwner { get; set; }

        public ConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;           
        }
      

        public IDbConnection GetConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
