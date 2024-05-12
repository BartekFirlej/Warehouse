namespace Warehouse.DTOs
{
    public class OrderRequest
    {
        public int CustomerId { get; set; }

        public int OrderMethodId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
