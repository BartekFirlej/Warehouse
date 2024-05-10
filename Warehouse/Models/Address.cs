﻿using Warehouse.DTOs;

namespace Warehouse.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public int Number { get; set; }

    public int CityId { get; set; }

    public virtual City City { get; set; } = null!;

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public static AddressResponse AddressToResponseDTO(Address address)
    {
        return new AddressResponse
        {
            AddressId = address.AddressId,
            Number = address.Number,
            CityId = address.CityId
        };
    }
}
