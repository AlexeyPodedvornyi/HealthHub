using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public class SickLeave
    {
        public int Id { get; set; }
        public int Hospital_Id { get; set; }
        public int Doc_Id { get; set; }
        public int Pat_Id { get; set; }
        public string diagnosis { get; set; }
        public DateTime Start_Term { get; set; }
        public DateTime End_Term { get; set; }

        public SickLeave(int id, int hospital_Id, int doc_Id, int pat_Id, string diagnosis, DateTime start_Term, DateTime end_Term)
        {
            Id = id;
            Hospital_Id = hospital_Id;
            Doc_Id = doc_Id;
            Pat_Id = pat_Id;
            this.diagnosis = diagnosis;
            Start_Term = start_Term;
            End_Term = end_Term;
        }
    }
}
