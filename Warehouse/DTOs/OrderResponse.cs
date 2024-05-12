namespace Warehouse.DTOs
{
    public class OrderResponse
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int OrderMethodId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
