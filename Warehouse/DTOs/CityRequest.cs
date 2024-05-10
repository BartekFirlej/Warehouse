namespace Warehouse.DTOs
{
    public class CityRequest
    {
        public string CityName { get; set; } = null!;

        public int VoivodeshipId { get; set; }

        public string PostalCode { get; set; } = null!;
    }
}
