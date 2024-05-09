namespace Warehouse.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int? Number { get; set; }

    public int? CityId { get; set; }

    public virtual City? City { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
