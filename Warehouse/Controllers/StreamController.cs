using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;
using Warehouse.DTOs;
using Warehouse.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("streams")]
    public class StreamController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IKafkaProducerService _kafkaProducerService;

        public StreamController(ICustomerService customerService, IProductService productService, IKafkaProducerService kafkaProducerService)
        {
            _customerService = customerService;
            _productService = productService;
            _kafkaProducerService = kafkaProducerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVisitsStream(int durationSeconds, int requestsPerSecond)
        {
            List<ProductWithProductTypeResponse> products = await _productService.GetProductsWithProductTypes();
            List<CustomerWithAddressResponse> customers = await _customerService.GetCustomersWithAddresses();

            TimeSpan delay = TimeSpan.FromSeconds(1.0 / requestsPerSecond);

            for (int i = 0; i < requestsPerSecond * durationSeconds; i++)
            {
                Random random = new Random();
                int randomIndex = random.Next(0, customers.Count);
                var randomCustomer = customers[randomIndex];
                randomIndex = random.Next(0, products.Count);
                var randomProduct = products[randomIndex];

                var productView = new CustomerProductResponse
                {
                    CustomerId = randomCustomer.CustomerId,
                    CustomerName = randomCustomer.CustomerName,
                    CustomerLastName = randomCustomer.CustomerLastName,
                    Email = randomCustomer.Email,
                    Phone = randomCustomer.Phone,
                    AddressId = randomCustomer.AddressId,
                    ProductId = randomProduct.ProductId,
                    Price = randomProduct.Price,
                    ProductName = randomProduct.ProductName,
                    ProductTypeId = randomProduct.ProductTypeId,
                    ProductTypeName = randomProduct.ProductTypeName,
                    Number = randomCustomer.Number,
                    CityId = randomCustomer.CityId,
                    CityName = randomCustomer.CityName,
                    PostalCode = randomCustomer.PostalCode,
                    VoivodeshipId = randomCustomer.VoivodeshipId,
                    VoivodeshipName = randomCustomer.VoivodeshipName,
                    CountryId = randomCustomer.CountryId,
                    CountryName = randomCustomer.CountryName
                };

                string json = JsonSerializer.Serialize(productView, new JsonSerializerOptions { WriteIndented = true });

                Console.WriteLine(json);

                await _kafkaProducerService.ProduceCustomerProduct("productView", json);

                await Task.Delay(delay);
            }

            return Ok();
        }
    }
}
