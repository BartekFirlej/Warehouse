namespace Warehouse.DTOs
{
    public class CustomerResponse
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerLastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int AddressId { get; set; }
    }
}
