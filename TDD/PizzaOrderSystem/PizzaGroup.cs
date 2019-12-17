namespace PizzaOrderSystem
{
    internal class PizzaGroup
    {
        public string PizzaName { get; }
        public int TotalPieces { get; }

        public PizzaGroup(string pizzaName, int totalPieces)
        {
            PizzaName = pizzaName;
            TotalPieces = totalPieces;
        }
    }
}