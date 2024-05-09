namespace Warehouse.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Voivodeship> Voivodeships { get; set; } = new List<Voivodeship>();
}
