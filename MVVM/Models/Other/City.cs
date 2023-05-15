using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class City
    {
        public int City_Id { get; set; }
        public string City_Name { get; set; }

        public City(int city_Id, string city_Name)
        {
            City_Id = city_Id;
            City_Name = city_Name;
        }
    }
}
