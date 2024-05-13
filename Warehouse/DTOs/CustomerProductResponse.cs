namespace Warehouse.DTOs
{
    public class CustomerProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int ProductTypeId { get; set; }

        public string ProductTypeName { get; set; } = null!;

        public decimal Price { get; set; }

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

        public override string ToString()
        {
            return $"ProductId: {ProductId}, ProductName: {ProductName}, ProductTypeId: {ProductTypeId}, " +
                   $"ProductTypeName: {ProductTypeName}, Price: {Price}, CustomerId: {CustomerId}, CustomerName: {CustomerName}, " +
                   $"CustomerLastName: {CustomerLastName}, Email: {Email}, Phone: {Phone}, " +
                   $"AddressId: {AddressId}, Number: {Number}, CityId: {CityId}, " +
                   $"CityName: {CityName}, VoivodeshipId: {VoivodeshipId}, PostalCode: {PostalCode}, " +
                   $"VoivodeshipName: {VoivodeshipName}, CountryId: {CountryId}, CountryName: {CountryName}";
        }
    }
}
