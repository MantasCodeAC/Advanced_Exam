using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_Exam.Models
{
    public abstract class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Product(int iD, string name, string type, string description, double price)
        {
            ID = iD;
            Name = name;
            Type = type;
            Description = description;
            Price = price;
        }
    }
    public class Food : Product
    {
        public bool Vegeterian { get; set; }
        public double Portion { get; set; } = 1.0;
        public Food(int iD, string name, string type, string description, double price, bool vegeterian, double portion) : base(iD, name, type, description, price)
        {
            Vegeterian = vegeterian;
            Portion = portion;
        }
    }
    public class Beverage : Product
    {
        public bool Alcoholic { get; set; }
        public Beverage(int iD, string name, string type, string description, double price, bool alcoholic) : base(iD, name, type, description, price)
        {
            Alcoholic = alcoholic;
        }
    }
}
