using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class DoctorSupervisions
    {
        public int Id { get; set; }
        public int Doc_Id { get; set; }
        public int Pat_Id { get; set; }
        public int Diagnosis { get; set; }
        public int Exams_Freq { get; set; }

        public DoctorSupervisions(int id, int doc_Id, int pat_Id, int diagnosis, int exams_Freq)
        {
            Id = id;
            Doc_Id = doc_Id;
            Pat_Id = pat_Id;
            Diagnosis = diagnosis;
            Exams_Freq = exams_Freq;
        }
    }
}
