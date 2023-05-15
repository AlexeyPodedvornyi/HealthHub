using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Patients
{
    public class Recipe
    {
        public int Rec_Id { get; set; }
        public int Doc_Id { get; set; }
        public int Pat_Id { get; set; }
        public string Medicine_Name { get; set; }
        public DateTime End_Term { get; set; }
        public DateTime Start_Term { get; set; }

        public Recipe(int rec_Id, int doc_Id, int pat_Id, string medicine_Name, DateTime end_Term, DateTime start_Term)
        {
            Rec_Id = rec_Id;
            Doc_Id = doc_Id;
            Pat_Id = pat_Id;
            Medicine_Name = medicine_Name;
            End_Term = end_Term;
            Start_Term = start_Term;
        }
    }
}
