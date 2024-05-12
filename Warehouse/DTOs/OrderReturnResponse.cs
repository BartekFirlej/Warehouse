namespace Warehouse.DTOs
{
    public class OrderReturnResponse
    {
        public int ReturnId { get; set; }

        public int OrderDetailId { get; set; }

        public DateTime ReturnDate { get; set; }

        public int Quantity { get; set; }

        public int ReturnReasonId { get; set; }
    }
}
