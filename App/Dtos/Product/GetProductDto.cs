using App.Models;

namespace App.Dtos
{
    public class GetProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public bool ForSale { get; set; }
        public Brands Brand { get; set; }
        public Units Unit { get; set; }

    }
}
