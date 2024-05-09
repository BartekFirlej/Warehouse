namespace Warehouse.DTOs
{
    public class ProductRequest
    {
        public string ProductName { get; set; } = null!;

        public int ProductTypeId { get; set; }

        public decimal Price { get; set; }
    }
}
