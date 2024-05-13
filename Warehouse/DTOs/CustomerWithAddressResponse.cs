namespace Warehouse.DTOs
{
    public class CustomerWithAddressResponse
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerLastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int AddressId { get; set; }

        public int Number { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; } = null!;

        public int VoivodeshipId { get; set; }

        public string PostalCode { get; set; } = null!;

        public string VoivodeshipName { get; set; } = null!;

        public int CountryId { get; set; }

        public string CountryName { get; set; } = null!;
    }
}
