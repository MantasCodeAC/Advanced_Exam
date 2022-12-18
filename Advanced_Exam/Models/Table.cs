using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Models
{
    public class Table
    {
        public int ID { get; set; }
        public int Seats { get; set; }
        public bool IsFree { get; set; } = true;
        public Table(int iD, int seats)
        {
            ID = iD;
            Seats = seats;
        }
      
    }
}
