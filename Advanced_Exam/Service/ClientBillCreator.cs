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
    public class ClientBillCreator:ISendEmail
    {
        public void CreateBillForClient(TableRepository tableRepository, OrderRepository orderRepository)
        {            
            int tableID = -1;
            var tables = tableRepository.Retrieve();
            Order? orderToBill = null;
            Console.WriteLine("Pasirinkite vieną iš žemiau išvardintų užimtų staliukų sąskaitai išrašyti:\n" +
                "(Norėdami atšaukti spauskite [0])\n");
            foreach(var table in tables)
            {
                if (!table.IsFree)
                {
                    Console.WriteLine($"Staliukas Nr.{table.ID}");
                }
            }
            while (tableID != 0)
            {
                try
                {
                    tableID = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Neteisingai įvestas pasirinkimas, bandykite iš naujo");
                    continue;
                }
                if(tableID == 0)
                {
                    Console.WriteLine("Langas išjungiamas...\n");
                    return;
                }
                else if (tableID >= 1 && tableID <= 8 && !tableRepository.Retrieve(tableID).IsFree)
                {
                    int ifPrint = 0;
                    orderToBill = orderRepository.orders.Last(x => x._Table.ID == tableID);
                    Console.WriteLine($"**********\nUžsakymo Nr.{orderToBill._ID} čekis\n" +
                        $"Užsakymo pateikimo laikas: {orderToBill._DateTime}\n" +
                        $"Užsakytų produktų sąrašas: ");
                    orderToBill._Products.ForEach(x => Console.WriteLine($"     {x.Name} {Math.Round(x.Price, 2)} Eur."));
                    Console.WriteLine($"Galutinė mokėtina suma: {Math.Round(orderToBill._Sum, 2)} Eur.");

                    Console.WriteLine("Ar norite atspausdinti čekį?\n" +
                        "[1]Taip  [2]Ne");
                    try
                    {
                        ifPrint = Int32.Parse(Console.ReadLine());
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Neteisingai įvestas pasirinkimas, čekis nespausdinamas. Operacija baigta");
                        break;
                    }
                    if (ifPrint == 1)
                    {
                        Console.WriteLine("Čekis sėkmingai atspausdintas");
                        break;
                    }
                    Console.WriteLine("Čekis nespausdinamas. Operacija baigta");
                    break;
                }
                Console.WriteLine("Prie įvesto staliuko šiuo metu užsakymų nėra. Įveskite kitą staliuką");
                continue;
            }
            SendEmail(orderToBill, orderRepository);
        }

        public bool SendEmail(Order order, OrderRepository orderRepository)
        {
            HTMLCreator hTMLCreator = new HTMLCreator();
            Console.WriteLine("Ar norite išsiųsti čekį el. paštu?\n" +
                "[1]Taip [2]Ne");
            bool success = false;
            int selectedOperation = 0;
            while(selectedOperation != 2)
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
                if(selectedOperation == 1)
                {
                    Console.WriteLine("Įveskite el. paštą: ");
                    string? email = Console.ReadLine();
                    hTMLCreator.CreateHTMLForClient(order);
                    Console.WriteLine($"Čekis išsiųstas nurodytu {email} el. paštu");
                    success = true;
                    break;
                }
                else if(selectedOperation == 2)
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
