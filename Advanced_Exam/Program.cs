using Advanced_Exam.Repositories;
using Advanced_Exam.Service;
using System.Linq.Expressions;

namespace Advanced_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            TableStatusChanger tableStatusChanger = new TableStatusChanger();
            TableRepository tableRepository = new TableRepository();
            OrderRepository orderRepository = new OrderRepository();
            OrderCreator creator = new OrderCreator();
            ClientBillCreator clientBillCreator = new ClientBillCreator();
            RestaurantBillCreator restaurantBillCreator = new RestaurantBillCreator();
            int programOff = 1;

            Console.WriteLine("Programa |Restorano Sistema| paleista\n**************\n");
            while (programOff !=0)
            {               
                Console.WriteLine("Pasirinkite veiksmą:\n" +
                    "[1]Pasodinti žmones prie staliuko ir užregistruoti užsakymą\n" +
                    "[2]Peržiūrėti/Pakeisti staliuko būseną\n" +
                    "[3]Sudaryti čekį klientui\n" +
                    "[4]Sudaryti čekį restoranui\n" +
                    "[0]Atsijungti nuo programos");
                try
                {
                    programOff = Int32.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Neteisingai įvestas pasirinkimas. Įveskite iš naujo\n");
                    continue;
                }
                switch (programOff)
                {
                    case 0:
                        Console.WriteLine("Programa išjungiama...");                        
                        break;
                    case 1:
                        creator.CreateAnOrder(tableRepository, orderRepository);
                        continue;
                    case 2:
                        tableStatusChanger.ChangeTableStatus(tableRepository);
                        break;
                    case 3:
                        clientBillCreator.CreateBillForClient(tableRepository, orderRepository);
                        break;
                    case 4:
                        restaurantBillCreator.CreateBillForRestaurant(orderRepository);
                        break;
                    default:
                        Console.WriteLine("Neteisingai įvestas pasirinkimas. Įveskite iš naujo\n");
                        continue;

                }

                
            }        
        }
    }
}