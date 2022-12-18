using Advanced_Exam.Models;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Service
{
    public class OrderCreator
    {
        ProductRepository productRepository = new ProductRepository();
        TableChooser tableChooser = new TableChooser();
        public List<Product> CreateProductsList()
        {
            List<Product> productsOfNewOrder = new List<Product>();
            int meniuNr=3;         
            while (meniuNr != 0)
            {
                Console.WriteLine("Pasirinkite meniu:\n[1]Maisto meniu\n[2]Gėrimų meniu\n[0]Patvirtinti ir uždaryti");
                try
                {
                    meniuNr = Int32.Parse(Console.ReadLine());
                }

                catch (Exception)
                {
                    Console.WriteLine("Neteisingas pasirinkimas. Įveskite iš naujo");
                    continue;
                }
                switch (meniuNr)
                {
                    case 1:
                        int selector = 1;
                        var a = productRepository.RetrieveFood();
                        foreach (var food in a)
                        {
                            Console.WriteLine($"[{food.ID}] {food.Name}  {Math.Round(food.Price,2)} Eur");
                        }
                        while (selector != 0)
                        {
                            Console.WriteLine("Įveskite patiekalo Nr., kurį norite pridėti:\n" +
                                "***Norėdami išeiti spauskite [0]");
                            try
                            {
                                selector = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Neteisingas įvestas pasirinkimas. Įveskite iš naujo");
                                continue;
                            }
                            if(selector>=10 && selector <= 16)
                            {
                                productsOfNewOrder.Add(productRepository.RetrieveFood(selector));
                                Console.WriteLine("Produktas pridėtas į užsakymą\n");
                            }
                            else if(selector!=0)
                            {
                                Console.WriteLine("Produkto pridėti nepavyko. Pasirinkite kitą produktą");
                            }
                        }
                        break;
                    case 2:
                        int selector1 = 1;
                        var b = productRepository.RetrieveBeverge();
                        foreach (var beverage in b)
                        {
                            Console.WriteLine($"[{beverage.ID}] {beverage.Name}  {Math.Round(beverage.Price,2)} Eur");
                        }
                        while (selector1 != 0)
                        {
                            Console.WriteLine("Įveskite gėrimo Nr., kurį norite pridėti:\n" +
                                "***Norėdami išeiti spauskite [0]");
                            try
                            {
                                selector1 = Int32.Parse(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Neteisingas įvestas pasirinkimas. Įveskite iš naujo");
                                continue;
                            }
                            if (selector1 >= 100 && selector1 <= 104)
                            {
                                productsOfNewOrder.Add(productRepository.RetrieveBeverage(selector1));
                                Console.WriteLine("Gėrimas pridėtas į užsakymą\n");
                            }
                            else if (selector1 != 0)
                            {
                                Console.WriteLine("Gėrimo pridėti nepavyko. Pasirinkite kitą gėrimą");
                            }
                        }
                        break;
                    case 0:
                        Console.WriteLine("Meniu išjungtas");
                        break;
                    default:
                        Console.WriteLine("Neteisingas pasirinkimas. Įveskite iš naujo");
                        continue;
                }                   
            }
            return productsOfNewOrder;
        }
        public Order CreateAnOrder(TableRepository tableRepository, OrderRepository orderRepository)
        {
            Order order = new Order();
            order._ID = orderRepository.orders.Count + 1;
            order._Table = tableChooser.ChooseATable(tableRepository);
            if (order._Table == null)
            {
                return null;
                System.Environment.Exit(0);
            }
            order._Products = CreateProductsList();
            order._DateTime = DateTime.Now;
            order._Sum = 0;
            Console.WriteLine($"\n*********\nNaujas užsakymas sėkmingai sukurtas.\n" +
                $"UŽSAKYMO INFORMACIJA:\nUžsakymo ID {order._ID}\n" +
                $"Laikas {order._DateTime}\nStaliuko Nr. {order._Table.ID}\nProduktai: ");
            foreach (var product in order._Products)
            {
                Console.WriteLine($"{product.Name}  {Math.Round(product.Price,2)} Eur.");
                order._Sum = order._Sum + Math.Round(product.Price,2);
            }
            Console.WriteLine($"Bendra užsakymo suma: {Math.Round(order._Sum,2)} Eur.\n");
            orderRepository.orders.Add(order);
            return order;
        }
    }

}
