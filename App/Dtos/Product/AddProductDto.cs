using App.Models;

namespace App.Dtos.Product
{
    public class AddProductDto
    {
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public bool ForSale { get; set; }
        public Brands Brand { get; set; }
        public Units Unit { get; set; }

    }
}