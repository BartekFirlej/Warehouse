using Microsoft.AspNetCore.Mvc;
using System;
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

        public StreamController(ICustomerService customerService, IProductService productService)
        {
            _customerService = customerService;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVisitsStream(int durationSeconds, int requestsPerSecond)
        {
            List<ProductResponse> products = await _productService.GetProducts();
            List<CustomerResponse> customers = await _customerService.GetCustomers();

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
                    ProductTypeId = randomProduct.ProductTypeId
                };

                Console.WriteLine(productView);

                await Task.Delay(delay);
            }

            return Ok();
        }
    }
}
