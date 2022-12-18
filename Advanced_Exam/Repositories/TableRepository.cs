using Advanced_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Repositories
{
    public class TableRepository
    {
        private List<Table> tables = new List<Table>();
        public TableRepository()
        {
            var text = System.IO.File.ReadAllLines(@"C:\Users\Vartotojas\Desktop\CodeAcademy\Table_Database.txt")
                .Select(x => x.Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries))
                .Where(x => x.Length > 1)
                .Select(x => new { TableID = x[0].Trim(), Seats = x[1].Trim() })
                .ToList();
            foreach (var element in text)
            {
                tables.Add(new Table(Int32.Parse(element.TableID), Int32.Parse(element.Seats)));
            }
        }
        public Table? Retrieve(int tableID)
        {
            var requiredTable = tables.Find(x => x.ID == tableID);
            return requiredTable;
        }
        public List<Table> Retrieve()
        {
            return tables;
        }
    }
}
