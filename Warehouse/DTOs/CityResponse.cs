namespace Warehouse.DTOs
{
    public class CityResponse
    {
        public int CityId { get; set; }

        public string CityName { get; set; } = null!;

        public int VoivodeshipId { get; set; }

        public string PostalCode { get; set; } = null!;
    }
}
