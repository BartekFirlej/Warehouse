namespace Warehouse.DTOs
{
    public class ProductWithProductTypeResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public decimal Price { get; set; }

        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; } = null!;
    }
}
