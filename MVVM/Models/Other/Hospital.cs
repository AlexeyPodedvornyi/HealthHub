using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class Hospital
    {
        public int Hospital_Id { get; set; }
        public string Address { get; set; }
        public int City_Id { get; set; }
        public string Hospital_Name { get; set; }

        public Hospital(int hospital_Id, string address, int city_Id, string hospital_Name)
        {
            Hospital_Id = hospital_Id;
            Address = address;
            City_Id = city_Id;
            Hospital_Name = hospital_Name;
        }
    }
}
