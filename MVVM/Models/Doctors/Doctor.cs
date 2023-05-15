using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class Doctor
    {
        public int Doc_Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Hospital_Id { get; set; }
        public int Spec_Id { get; set; }
        public int Pos_Id { get; set; }
        public string Middle_Name { get; set; }

        public Doctor(int doc_id, string fst_name, string lst_name, string mdl_name, int hospital_id, int spec_id, int pos_id)
        {
            Doc_Id = doc_id;
            First_Name = fst_name;
            Last_Name = lst_name;
            Middle_Name = mdl_name;
            Hospital_Id = hospital_id;
            Spec_Id = spec_id;
            Pos_Id = pos_id;
        }
    }
}
