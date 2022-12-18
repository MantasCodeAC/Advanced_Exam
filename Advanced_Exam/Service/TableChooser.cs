using Advanced_Exam.Models;
using Advanced_Exam.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Service
{
    public class TableChooser
    {
        public Table ChooseATable(TableRepository tableRepository)
        {
            var tables = tableRepository.Retrieve();
            bool checker = true;
            Table? tableToTry = null;
            Random random = new Random();
            int peoplecount = random.Next(1, 12);

            Console.WriteLine($"\n***************\n" +
                $"Į restoraną atėjusių žmonių skaičius: {peoplecount}\n" +
                $"_________________________\n" +
                $"Pasirinkite vieną numerį iš laisvų staliukų:\n");
            Console.WriteLine("Staliukų sąrašas: ");
            foreach(var table in tables)
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

            while (checker)
            {
                int tableID = 0;
                Console.WriteLine("(Jei nėra pakankamai laisvų vietų ir norite išeiti spauskite [0])\n");
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
                    tableToTry = null;
                    break;
                }
                tableToTry = tableRepository.Retrieve(tableID);
                if (tableID >= 1 && tableID <= 8 && tableToTry.IsFree)
                {
                    if (peoplecount <= tableToTry.Seats)
                    {
                        Console.WriteLine("Žmonės sėkmingai susodinti, galima pradėti pildyti užsakymą\n");
                        tableToTry.IsFree = false;
                    }
                    else
                    {
                        Console.WriteLine("Vietų prie staliuko per mažai. Pasirinkite kitą staliuką");
                        continue;
                    }
                }
                else
                {
                    Console.WriteLine("Šio staliuko negalima pasirinkti. Rinkitės iš galimų sąrašo");
                    continue;
                }
                checker = false;
            }
            return tableToTry;
        }
    }
}
