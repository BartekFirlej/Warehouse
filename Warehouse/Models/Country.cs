using System.Diagnostics.Metrics;
using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; } = null!;

    public virtual ICollection<Voivodeship> Voivodeships { get; set; } = new List<Voivodeship>();

    public static CountryResponse CountryToResponseDTO(Country country)
    {
        return new CountryResponse
        {
            CountryId = country.CountryId,
            CountryName = country.CountryName
        };
    }

    public static Country RequestDTOToCountryy(CountryRequest countryDetails)
    {
        return new Country
        {
            CountryName = countryDetails.CountryName
        };
    }
}
