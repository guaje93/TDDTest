namespace PizzaOrderSystem
{
    internal class OrderPosition
    {
        private string _name;
        private int _pieces;
        private string _pizzaName;

        public OrderPosition(string name, int pieces, string pizzaName)
        {
            this.Name = name;
            this.Pieces = pieces;
            this.PizzaName = pizzaName;
        }

        public string Name { get => _name; private set => _name = value; }
        public int Pieces { get => _pieces; private set => _pieces = value; }
        public string PizzaName { get => _pizzaName; set => _pizzaName = value; }
    }
}