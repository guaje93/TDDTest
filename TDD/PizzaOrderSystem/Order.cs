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

        public Order()
        {
        }

        internal void Add(OrderPosition orderPosition)
        {
            _positions.Add(orderPosition);
        }

        internal bool IsValid()
        {
            return AllPiecesAreDivisibleBy8() && GroupedByNamePiecesAreDivisableBy4();
        }

        private bool GroupedByNamePiecesAreDivisableBy4()
        {
            return _positions.GroupBy(p => p.Name)
                                         .Select(p => new
                                         {
                                             PizzaName = p.Key,
                                             TotalPieces = p.Sum(x => x.Pieces)
                                         })
                                         .All(g => g.TotalPieces % 4 == 0);
        }


        private bool AllPiecesAreDivisibleBy8()
        {
            return _positions.Sum(p => p.Pieces) % 8 == 0;
        }
    }
}