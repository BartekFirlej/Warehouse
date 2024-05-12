namespace Warehouse.DTOs
{
    public class OrderReturnRequest
    {
        public int OrderDetailId { get; set; }

        public DateTime ReturnDate { get; set; }

        public int Quantity { get; set; }

        public int ReturnReasonId { get; set; }
    }
}
