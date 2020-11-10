namespace ShoppingCart.Domain
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public decimal Cost { get; set; }

        public int StockLevel { get; set; }
    }
}
