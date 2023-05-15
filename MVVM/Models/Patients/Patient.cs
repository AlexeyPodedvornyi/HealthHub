using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public class Patient
    {
        public int Pat_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public DateTime Date_Of_Birthday { get; set; }
        public int? Family_Id { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int City_Id { get; set; }
        public string Passwrod { get; set; }
        public string? Refresh_Token { get; set; }

        public Patient(int pat_Id, string first_Name, string last_Name, DateTime date_Of_Birthday, int? family_Id,
            string email, string gender, string address, int city_Id, string passwrod, string? refresh_Token)
        {
            Pat_Id = pat_Id;
            First_Name = first_Name;
            Last_Name = last_Name;
            Date_Of_Birthday = date_Of_Birthday;
            Family_Id = family_Id;
            Email = email;
            Gender = gender;
            Address = address;
            City_Id = city_Id;
            Passwrod = passwrod;
            Refresh_Token = refresh_Token;
        }

    }
}
