using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PizzaExampleTest")]
namespace PizzaOrderSystem
{
    internal class Order
    {
        private IList<OrderPosition> _positions = new List<OrderPosition>();

        internal IList<OrderPosition> Positions { get => _positions; }

        public Order()
        {
        }

        internal void Add(OrderPosition orderPosition)
        {
            Positions.Add(orderPosition);
        }

        internal bool IsValid()
        {
            return AllPiecesAreDivisibleBy8() && GroupedByNamePiecesAreDivisableBy4();
        }

        private bool GroupedByNamePiecesAreDivisableBy4()
        {
            return Positions.GroupBy(p => p.Name)
                                         .Select(p => new
                                         {
                                             PizzaName = p.Key,
                                             TotalPieces = p.Sum(x => x.Pieces)
                                         })
                                         .All(g => g.TotalPieces % 4 == 0);
        }


        private bool AllPiecesAreDivisibleBy8()
        {
            return Positions.Sum(p => p.Pieces) % 8 == 0;
        }
    }

    public class Billing
    {
        private Menu menu;

        public Billing(Menu menu)
        {
            this.menu = menu;
        }

        internal Dictionary<string, double> Calculate(Order order)
        {
            var dict = new Dictionary<string, double>();
            var val = order.Positions.GroupBy(p => p.Name).Select(p => new
            {
                Name = p.Key,
                Value = p.Sum(g => Price(g.PizzaName, g.Pieces))
            });
            foreach (var item in val)
            {
                dict.Add(item.Name, item.Value);
            }

            return dict;
        }

        private double Price(string pizzaName, int pieces)
        {
            return this.menu.GetPizzaPrice(pizzaName) / 8 * pieces;

        }
    }
}