namespace Warehouse.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerLastName { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public int? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
