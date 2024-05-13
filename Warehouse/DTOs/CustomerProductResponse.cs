﻿using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warehouse.DTOs
{
    public class CustomerProductResponse
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int ProductTypeId { get; set; }

        public decimal Price { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string CustomerLastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Phone { get; set; } = null!;

        public int AddressId { get; set; }

        public override string ToString()
        {
            return $"ProductId: {ProductId}, ProductName: {ProductName}, ProductTypeId: {ProductTypeId}, " +
                   $"Price: {Price}, CustomerId: {CustomerId}, CustomerName: {CustomerName}, " +
                   $"CustomerLastName: {CustomerLastName}, Email: {Email}, Phone: {Phone}, " +
                   $"AddressId: {AddressId}";
        }
    }
}
