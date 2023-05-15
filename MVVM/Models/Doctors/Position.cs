using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthHub.MVVM.Models.Doctors
{
    public class Position
    {
        public int Pos_Id { get; set; }
        public string Post { get; set; }

        public Position(int pos_Id, string post)
        {
            Pos_Id = pos_Id;
            Post = post;
        }
    }
}
