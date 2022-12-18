using Advanced_Exam.Models;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Interface
{
    public interface ISendEmail
    {
        public bool SendEmail(Order order, OrderRepository orderRepository);
    }
}
