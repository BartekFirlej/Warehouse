using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            List<CustomerResponse> customers;
            try
            {
                customers = await _customerService.GetCustomers();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(customers);
        }

        [HttpGet("addresses")]
        public async Task<IActionResult> GetCustomersWithAddresses()
        {
            List<CustomerWithAddressResponse> customers;
            try
            {
                customers = await _customerService.GetCustomersWithAddresses();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(customers);
        }

        [HttpGet("{customerid}")]
        public async Task<IActionResult> GetCustomers(int customerid)
        {
            CustomerResponse customer;
            try
            {
                customer = await _customerService.GetCustomer(customerid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer(CustomerRequest customerDetails)
        {
            CustomerResponse addedCustomer;
            try
            {
                addedCustomer = await _customerService.PostCustomer(customerDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostCustomer), addedCustomer);
        }
    }
}
