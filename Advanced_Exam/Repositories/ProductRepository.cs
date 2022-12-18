using Advanced_Exam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Repositories
{
    public class ProductRepository
    {
        private List<Food> foodProducts = new List<Food>();
        private List<Beverage> beverageProducts = new List<Beverage>();
        public ProductRepository()
        {
            var text = System.IO.File.ReadAllLines(@"C:\Users\Vartotojas\Desktop\CodeAcademy\Food_Database.txt")
                .Select(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(x => x.Length > 1)
                .Select(x => new { 
                    Name = x[0].Trim(), 
                    Type = x[1].Trim(), 
                    Description = x[2].Trim(),
                    Price = x[3].Trim(), 
                    Vegeterian = x[4].Trim(), 
                    Portion = x[5].Trim(),
                    ID = x[6].Trim()
                })
                .ToList();
            foreach (var element in text)
            {
                foodProducts.Add(new Food(Int32.Parse(element.ID), element.Name, element.Type, element.Description, 
                    Double.Parse(element.Price), Boolean.Parse(element.Vegeterian), Double.Parse(element.Portion)));
            }

            var text1 = System.IO.File.ReadAllLines(@"C:\Users\Vartotojas\Desktop\CodeAcademy\Beverage_Database.txt")
                .Select(x => x.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries))
                .Where(x => x.Length > 1)
                .Select(x => new {
                    Name = x[0].Trim(),
                    Type = x[1].Trim(),
                    Description = x[2].Trim(),
                    Price = x[3].Trim(),
                    Alcoholic = x[4].Trim(),                  
                    ID = x[5].Trim()
                })
                .ToList();
            foreach (var element in text1)
            {
                beverageProducts.Add(new Beverage(Int32.Parse(element.ID), element.Name, element.Type, element.Description,
                    Double.Parse(element.Price), Boolean.Parse(element.Alcoholic)));
            }
        }
        public List<Food> RetrieveFood()
        {
            return foodProducts;
        }
        public Food? RetrieveFood(int foodID)
        {
            var requiredFood = foodProducts.Find(x => x.ID == foodID);
            return requiredFood;
        }
        public List<Beverage> RetrieveBeverge()
        {
            return beverageProducts;
        }
        public Beverage? RetrieveBeverage(int beverageID)
        {
            var requiredBeverage = beverageProducts.Find(x => x.ID == beverageID);
            return requiredBeverage;
        }
    }
}
