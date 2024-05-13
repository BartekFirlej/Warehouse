using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string CustomerName { get; set; } = null!;

    public string CustomerLastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public int AddressId { get; set; }

    public virtual Address Address { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public static CustomerResponse CustomerToResponseDTO(Customer customer)
    {
        return new CustomerResponse
        {
            CustomerId = customer.CustomerId,
            CustomerName = customer.CustomerName,
            CustomerLastName = customer.CustomerLastName,
            Email = customer.Email,
            Phone = customer.Phone,
            AddressId = customer.AddressId
        };
    }

    public static CustomerWithAddressResponse CustomerToCustomerWithAddressResponseDTO(Customer customer)
    {
        return new CustomerWithAddressResponse
        {
            CustomerId = customer.CustomerId,
            CustomerName = customer.CustomerName,
            CustomerLastName = customer.CustomerLastName,
            Email = customer.Email,
            Phone = customer.Phone,
            AddressId = customer.AddressId,
            Number = customer.Address.Number,
            CityId = customer.Address.CityId,
            CityName = customer.Address.City.CityName,
            PostalCode = customer.Address.City.PostalCode,
            VoivodeshipId = customer.Address.City.VoivodeshipId,
            VoivodeshipName = customer.Address.City.Voivodeship.VoivodeshipName,
            CountryId = customer.Address.City.Voivodeship.CountryId,
            CountryName = customer.Address.City.Voivodeship.Country.CountryName
        };
    }

    public static Customer RequestDTOToCustomer(CustomerRequest customerDetails)
    {
        return new Customer
        {
            CustomerName = customerDetails.CustomerName,
            CustomerLastName = customerDetails.CustomerLastName,
            Email = customerDetails.Email,
            Phone = customerDetails.Phone,
            AddressId = customerDetails.AddressId
        };
    }
}
