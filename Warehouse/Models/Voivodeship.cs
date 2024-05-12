using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class Voivodeship
{
    public int VoivodeshipId { get; set; }

    public string VoivodeshipName { get; set; } = null!;

    public int CountryId { get; set; }

    public virtual ICollection<City> Cities { get; set; } = new List<City>();

    public virtual Country Country { get; set; } = null!;

    public static VoivodeshipResponse VoivodeshipToResponseDTO(Voivodeship voivodeship)
    {
        return new VoivodeshipResponse
        {
            VoivodeshipId = voivodeship.VoivodeshipId,
            VoivodeshipName = voivodeship.VoivodeshipName,
            CountryId = voivodeship.CountryId
        };
    }

    public static Voivodeship RequestDTOToVoivodeship(VoivodeshipRequest voivodeshipDetails)
    {
        return new Voivodeship
        {
            VoivodeshipName = voivodeshipDetails.VoivodeshipName,
            CountryId = voivodeshipDetails.CountryId
        };
    }
}
