using App.Models;

namespace App.Dtos
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public Brands Brand { get; set; }
    }
}
