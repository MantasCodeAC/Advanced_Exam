using Advanced_Exam.Models;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Interface
{
    public interface ICreateHTML
    {
        public bool CreateHTMLForClient(Order order);
        public void CreateHTMLForRestaurant(OrderRepository orderRepository);
    }
}
