namespace Warehouse.Models;

public partial class Voivodeship
{
    public int VoivodeshipId { get; set; }

    public string VoivodeshipName { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country Country { get; set; } = null!;
}
