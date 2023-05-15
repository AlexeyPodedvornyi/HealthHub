using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class Visit
    {
        public int Visit_Id { get; set; }
        public int Pat_Id { get; set; }
        public int Doc_Id { get; set; }
        public DateOnly Visit_Date { get; set; }
        public bool Active { get; set; }
        public TimeOnly Visit_Time { get; set; }

        public Visit(int visit_Id, int pat_Id, int doc_Id, DateOnly visit_Date, bool active, TimeOnly visit_Time)
        {
            Visit_Id = visit_Id;
            Pat_Id = pat_Id;
            Doc_Id = doc_Id;
            Visit_Date = visit_Date;
            Active = active;
            Visit_Time = visit_Time;
        }
    }
}
