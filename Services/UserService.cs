using HealthHub.MVVM.Model;
using HealthHub.Services.Factories;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.Services
{
    public class UserService : IUserService
    {
        private readonly IConnectionProviderFactory _connectionProviderFactory;
        private readonly IUserFactory _userFactory;

        public UserService(IConnectionProviderFactory connectionProviderFactory, IUserFactory userFactory)
        {
            _connectionProviderFactory = connectionProviderFactory;
            _userFactory = userFactory;
        }
        public IUser? GetUser(string login)
        {
            var connectionProvider = _connectionProviderFactory.Create("unauthorized");
            if(connectionProvider is null) return null;

            using NpgsqlConnection connection = (NpgsqlConnection)connectionProvider.GetConnection();
            connection.Open();

            var cmdSelectAdmins = new NpgsqlCommand("SELECT * FROM public.\"adminAuthInfo\" WHERE login = @login", connection);
            cmdSelectAdmins.Parameters.AddWithValue("@login", login);

            var reader = cmdSelectAdmins.ExecuteReader();
            if (reader.Read())
            {
                return _userFactory.Create(reader, "admin")!;
            }

            reader.Close();
            var cmdSelectDocs = new NpgsqlCommand("SELECT public.\"docAuthInfo\".login as login,public.\"docAuthInfo\".password, public.\"roles\".role as role FROM public.\"docAuthInfo\" " +
                "INNER JOIN public.\"roles\" ON public.\"roles\".id = public.\"docAuthInfo\".role_id WHERE login = @login", connection);
            cmdSelectDocs.Parameters.AddWithValue("@login", login);

            reader = cmdSelectDocs.ExecuteReader();
            if (reader.Read())
            {
                return _userFactory.Create(reader, "doctor")!;
            }

            return null;
        }
    }
}
