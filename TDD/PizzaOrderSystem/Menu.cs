using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderSystem
{
    public class Menu
    {
        public Menu()
        {

        }

        public IEnumerable<MenuPosition> Items => new List<MenuPosition>
        {
            new MenuPosition("4 sery", 20),
            new MenuPosition("poznanska", 30)
        };
        public double GetPizzaPrice(string name)
        { 
            return Items.FirstOrDefault(p => p.Name == name).Price;
        }
    }

    public class MenuPosition
    {
        public string Name { get; }
        public double Price { get; }

        public MenuPosition(string name, double price)
        {
            Name = name;
            Price = price;
        }

    }
}