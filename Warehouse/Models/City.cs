namespace Warehouse.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int VoivodeshipId { get; set; }

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Voivodeship Voivodeship { get; set; } = null!;
}
