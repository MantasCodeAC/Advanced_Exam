using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Models
{
    public class Order
    {
        public int _ID { get; set; }
        public Table _Table { get; set; }
        public List<Product> _Products { get; set; }
        public DateTime _DateTime { get; set; }
        public double _Sum { get; set; }
    }
}
