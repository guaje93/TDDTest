using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PizzaOrderSystem
{
    public class PizzaTests
    {
        [Fact]
        public void When_one_person_orders_8_pieces_then_order_is_valid() 
        {
            var order = new Order();

            order.Add(new OrderPosition("Arek", 8 , "4 sery"));
            Assert.True(order.IsValid());
        }
    }
}
