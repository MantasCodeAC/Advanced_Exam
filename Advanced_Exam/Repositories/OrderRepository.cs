using Advanced_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Repositories
{
    public class OrderRepository
    {
        public List<Order> orders = new List<Order>();
        public Order? Retrieve(int orderID)
        {
            var requiredOrder = orders.Find(x => x._ID == orderID);
            return requiredOrder;
        }
    }
}
