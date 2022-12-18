using Advanced_Exam.Interface;
using Advanced_Exam.Models;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Service
{
    public class HTMLCreator : ICreateHTML
    {
        public bool CreateHTMLForClient(Order order)
        {
            string clientBill = $"<html><head><h2>Kliento čekis</h2></head>" +
                $"<body><h3>Užsakymas Nr.{order._ID}</h3>" +
                $"<p>Užsakymo pateikimo laikas: {order._DateTime}</p>" +
                $"<p>Užsakytų produktų sąrašas: </p>";

            foreach(var product in order._Products)
            {
                clientBill = clientBill + $"<p><i>&emsp;&emsp;&emsp;{product.Name} {Math.Round(product.Price, 2)} Eur.</i></p>";
            }
            clientBill = clientBill + $"<p><b>Galutinė mokėtina suma: {Math.Round(order._Sum, 2)} Eur.</b></p></body></html>";
            File.WriteAllText("htmlClientReport.html", clientBill);
            return true;
        }

        public void CreateHTMLForRestaurant(OrderRepository orderRepository)
        {
            double finalSum = 0;
            string restaurantBill = $"<html><head><h2>Restorano {orderRepository.orders[0]._DateTime.Month} mėnesio " +
                $"{orderRepository.orders[0]._DateTime.Day} dienos čekis</h2></head>";
            foreach (var order in orderRepository.orders)
            {
                finalSum = finalSum + order._Sum;
                restaurantBill = restaurantBill +
                    $"<body><h3>Užsakymas Nr.{order._ID}</h3>" +
                    $"<p>Užsakymo pateikimo laikas: {order._DateTime}</p>" +
                    $"<p>Užsakymo suma <i>{Math.Round(order._Sum, 2)} Eur.</i></p>";
            }
            restaurantBill = restaurantBill + $"<p><b>Šiuo momentu restorano dienos čekį sudaro {Math.Round(finalSum, 2)} Eur.</b></p>";
            File.WriteAllText("htmlRestaurantReport.html", restaurantBill);
        }
    }
}
