using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaOrderSystem
{
    internal class Order
    {
        private IList<OrderPosition> _positions = new List<OrderPosition>();

        public Order()
        {
        }

        internal void Add(OrderPosition orderPosition)
        {
            _positions.Add(orderPosition);
        }

        internal bool IsValid()
        {
            return _positions.Sum(p => p.Pieces) % 8 == 0 && _positions.GroupBy(p => p.Name)
                             .Select(p => new
                             {
                                 PizzaName = p.Key,
                                 TotalPieces = p.Sum(x => x.Pieces)
                             })
                             .All(g => g.TotalPieces % 4 == 0);
        }
    }
}