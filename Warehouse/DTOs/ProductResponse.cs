namespace Warehouse.DTOs
{
    public class ProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int ProductTypeId { get; set; }

        public decimal Price { get; set; }
    }
}
