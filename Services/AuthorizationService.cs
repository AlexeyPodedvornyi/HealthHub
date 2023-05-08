using HealthHub.Interfaces;
using HealthHub.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Configuration;

namespace HealthHub.Services
{
    public class AuthorizationService
    {


        //public IUser? GetUser(string login)
        //{
        //    using var connection = new NpgsqlConnection(ConfigurationManager.ConnectionStrings["adminRole"].ConnectionString);
        //    connection.Open();

        //    IUser? receivedUser = null;
        //    var cmdSelectAdmins = new NpgsqlCommand("SELECT * FROM public.\"adminAuthInfo\" WHERE login = @login", connection);
        //    var cmdSelectDocs = new NpgsqlCommand("SELECT * FROM public.\"docAuthInfo\" WHERE login = @login", connection);
        //    cmdSelectAdmins.Parameters.AddWithValue("@login", login);
        //    cmdSelectDocs.Parameters.AddWithValue("@login", login);

        //    var reader = cmdSelectAdmins.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        receivedUser =  new Admin(reader.GetString(reader.GetOrdinal("login")), reader.GetString(reader.GetOrdinal("password")));
        //    }
        //    else
        //    {
        //        reader.Close();
        //        reader = cmdSelectDocs.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            receivedUser = new Doctor(reader.GetString(reader.GetOrdinal("login")), reader.GetString(reader.GetOrdinal("password")), reader.GetString(reader.GetOrdinal("password")));
        //        }
        //    }

        //    return receivedUser;
        //}
    }
}
