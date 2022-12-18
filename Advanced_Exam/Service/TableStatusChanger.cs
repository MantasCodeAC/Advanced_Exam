using Advanced_Exam.Models;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Service
{
    public class TableStatusChanger
    {
        public void ChangeTableStatus(TableRepository tableRepository)
        {
            int selector = 1;
            while(selector != 0)
            {
                var tables = tableRepository.Retrieve();
                Table? requiredTable = null;
                foreach (var table in tables)
                {
                    if (table.IsFree)
                    {
                        Console.WriteLine($"Staliukas Nr.{table.ID}({table.Seats}) LAISVAS");
                    }
                    else
                    {
                        Console.WriteLine($"Staliukas Nr.{table.ID}({table.Seats}) UŽIMTAS");
                    }
                }
                Console.WriteLine("\nĮveskite staliuką, kurį norite pažymėti kaip atlaisvintą\n" +
                    "[0]Jeigu norite palikti šį langą\n");
                try
                {
                    selector = Int32.Parse(Console.ReadLine());
                    requiredTable = tableRepository.Retrieve(selector);
                }
                catch (Exception)
                {
                    Console.WriteLine("Staliuko su tokiu numeriu nėra.\n");
                    continue;
                }
                if (selector == 0)
                {
                    Console.WriteLine("Staliukų sąrašas išjungiamas...\n");
                    break;
                }
                else if (selector >= 1 && selector <= 8 && !requiredTable.IsFree)
                {
                    requiredTable.IsFree = true;
                    Console.WriteLine($"Staliukas Nr.{requiredTable.ID} atlaisvintas sėkmingai\n");
                    break;
                }
                else if (selector < 1 || selector > 8)
                {                   
                    Console.WriteLine($"Staliuko su tokiu numeriu nėra\n");
                    continue;
                }
                else
                {
                    Console.WriteLine($"Staliukas Nr.{requiredTable.ID} jau yra laisvas. Pasirinkite kitą staliuką\n");
                    continue;
                }
            }                      
        }
    }
}
