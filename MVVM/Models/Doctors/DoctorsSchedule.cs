using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class DoctorsSchedule
    {
        public int Id { get; set; }
        public int Doc_Id { get; set; }
        public DateOnly Base_Date { get; set; }
        public TimeOnly Start_Time { get; set; }
        public TimeOnly End_Time { get; set; }

        public DoctorsSchedule(int id, int doc_Id, DateOnly base_Date, TimeOnly start_Time, TimeOnly end_Time)
        {
            Id = id;
            Doc_Id = doc_Id;
            Base_Date = base_Date;
            Start_Time = start_Time;
            End_Time = end_Time;
        }
    }
}
