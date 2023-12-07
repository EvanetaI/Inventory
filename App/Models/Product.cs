namespace App.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public bool ForSale { get; set; } = true;
        public Units Unit { get; set; }
        public Brands Brand { get; set; }
    }
}
