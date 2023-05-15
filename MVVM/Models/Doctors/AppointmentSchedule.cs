using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class AppointmentSchedule
    {
        public int Id { get; set; }
        public int Doc_Id { get; set; }
        public string Visit_Time { get; set; }
        public bool Active { get; set; }
        public DateOnly Visit_Date { get; set; }

        public AppointmentSchedule(int id, int doc_Id, string visit_Time, bool active, DateOnly visit_Date)
        {
            Id = id;
            Doc_Id = doc_Id;
            Visit_Time = visit_Time;
            Active = active;
            Visit_Date = visit_Date;
        }
    }
}
