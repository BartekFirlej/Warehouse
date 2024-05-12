using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class City
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public int VoivodeshipId { get; set; }

    public string PostalCode { get; set; } = null!;

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual Voivodeship Voivodeship { get; set; } = null!;

    public static CityResponse CityToResponseDTO(City city)
    {
        return new CityResponse
        {
            CityId = city.CityId,
            CityName = city.CityName,
            PostalCode = city.PostalCode,
            VoivodeshipId = city.VoivodeshipId
        };
    }

    public static City RequestDTOToCity(CityRequest cityDetails)
    {
        return new City
        {
            CityName = cityDetails.CityName,
            PostalCode = cityDetails.PostalCode,
            VoivodeshipId = cityDetails.VoivodeshipId
        };
    }
}
