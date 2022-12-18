using Advanced_Exam.Interface;
using Advanced_Exam.Models;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Service
{
    public class RestaurantBillCreator:ISendEmail
    {
        public void CreateBillForRestaurant(OrderRepository orderRepository)
        {
            HTMLCreator hTMLCreator = new HTMLCreator();
            double finalSum = 0;
            Console.WriteLine("Restorano čekis (Dienos Suvestinė)");
            foreach(var order in orderRepository.orders)
            {
                finalSum = finalSum + order._Sum;
                Console.WriteLine($"**********\n" +
                    $"Užsakymas Nr.{order._ID}\n" +
                    $"Laikas {order._DateTime}\n" +
                    $"Užsakymo suma {Math.Round(order._Sum,2)} Eur.\n\n");
            }
            Console.WriteLine($"Šiuo momentu restorano dienos čekį sudaro {Math.Round(finalSum,2)} Eur.\n" +
                $"Spausdinamas ir įrašomas čekis...\n");
            hTMLCreator.CreateHTMLForRestaurant(orderRepository);
            if(finalSum == 0)
            {
                return;
            }
            SendEmail(orderRepository.orders[0], orderRepository);
        }
        public bool SendEmail(Order order, OrderRepository orderRepository)
        {
            HTMLCreator hTMLCreator = new HTMLCreator();
            Console.WriteLine("Ar norite išsiųsti čekį el. paštu?\n" +
                "[1]Taip [2]Ne");
            bool success = false;
            int selectedOperation = 0;
            while (selectedOperation != 2)
            {
                try
                {
                    selectedOperation = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Neteisingai įvestas pasirinkimas, bandykite iš naujo");
                    continue;
                }
                if (selectedOperation == 1)
                {
                    Console.WriteLine("Įveskite el. paštą: ");
                    string? email = Console.ReadLine();
                    hTMLCreator.CreateHTMLForRestaurant(orderRepository);
                    Console.WriteLine($"Čekis išsiųstas nurodytu {email} el. paštu");
                    success = true;
                    break;
                }
                else if (selectedOperation == 2)
                {
                    Console.WriteLine("Čekis nesiunčiamas. Langas uždaromas...\n");
                    break;
                }
                Console.WriteLine("Neteisingai įvestas pasirinkimas, bandykite iš naujo");
                continue;
            }
            return success;
        }
    }
}
