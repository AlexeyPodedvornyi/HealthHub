using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Other
{
    public class Family
    {
        public int Fam_Id { get; set; }
        public int Fam_Doc_Id { get; set; }
        public int Head_Fam_Id { get; set; }
        public bool Approved { get; set; }

        public Family(int fam_Id, int fam_Doc_Id, int head_Fam_Id, bool approved)
        {
            Fam_Id = fam_Id;
            Fam_Doc_Id = fam_Doc_Id;
            Head_Fam_Id = head_Fam_Id;
            Approved = approved;
        }
    }
}
