﻿using PizzaOrderSystem;
using Xunit;

namespace PizzaExampleTest
{
    public class PizzaTests
    {
        private readonly Order _order;
        public PizzaTests()
        {
            _order = new Order();
        }

        [Fact]
        public void When_one_person_orders_8_pieces_then_order_is_valid()
        {
            _order.Add(new OrderPosition("Arek", 8, "4 sery"));
            Assert.True(_order.IsValid());
        }

        [Fact]
        public void When_sum_of_pieces_is_not_divisible_by_8_order_is_no_valid()
        {

            _order.Add(new OrderPosition("Arek", 3, "4 sery"));
            _order.Add(new OrderPosition("Arek", 4, "4 sery"));
            Assert.False(_order.IsValid());
        }

        [Fact]
        public void When_two_people_order_total_8_pieces__of_different_pizza_and_not_a_half_then_order_is_invalid()
        {
            _order.Add(new OrderPosition("Arek", 3, "4 sery"));
            _order.Add(new OrderPosition("Ola", 5, "poznanska"));
            Assert.False(_order.IsValid());
        }

        [Fact]
        public void When_two_people_order_four_pieces_of_different_pizza_then_order_is_invalid()
        {
            _order.Add(new OrderPosition("Arek", 4, "4 sery"));
            _order.Add(new OrderPosition("Ola", 4, "poznanska"));
            Assert.True(_order.IsValid());
        }

        [Fact]
        public void When_three_people_order_four_pieces_of_different_pizzas_each_other_is_invalid()
        {
            _order.Add(new OrderPosition("Arek", 4, "4 sery"));
            _order.Add(new OrderPosition("Ola", 4, "poznanska"));
            _order.Add(new OrderPosition("Jarek", 4, "poznanska"));
            Assert.False(_order.IsValid());
        }

        [Fact]
        public void Billing_returns_name_and_price_for_each_person_on_the_order()
        {
            Order exampleOrder = CreateTestOrder();
            var menu = new Menu(); 
            var billing = new Billing(menu);
            var bill = billing.Calculate(exampleOrder);
            Assert.Equal(25, bill["Arek"]);
            Assert.Equal(15, bill["Ola"]);



        }

        private static Order CreateTestOrder()
        {
            var exampleOrder = new Order();
            exampleOrder.Add(new OrderPosition("Arek", 4, "4 sery"));
            exampleOrder.Add(new OrderPosition("Ola", 4, "poznanska"));
            exampleOrder.Add(new OrderPosition("Arek", 4, "poznanska"));
            return exampleOrder;
        }
    }
}
