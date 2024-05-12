using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface ICustomerService
    {
        public Task<List<CustomerResponse>> GetCustomers();
        public Task<CustomerResponse> GetCustomer(int customerId);
        public Task<Customer> CheckCustomer(int customerId);
        public Task<CustomerResponse> PostCustomer(CustomerRequest customerDetails);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressService _addressService;

        public CustomerService(ICustomerRepository customerRepository, IAddressService addressService)
        {
            _customerRepository = customerRepository;
            _addressService = addressService;
        }

        public async Task<List<CustomerResponse>> GetCustomers()
        {
            var customers = await _customerRepository.GetCustomers();
            if (!customers.Any())
                throw new Exception("Not found any customers.");
            return customers;
        }

        public async Task<CustomerResponse> GetCustomer(int customerId)
        {
            var customer = await _customerRepository.GetCustomer(customerId);
            if (customer == null)
                throw new Exception(String.Format("Not found any customer with id {0}.", customerId));
            return customer;
        }

        public async Task<Customer> CheckCustomer(int customerId)
        {
            var customer = await _customerRepository.CheckCustomer(customerId);
            if (customer == null)
                throw new Exception(String.Format("Not found any customer with id {0}.", customerId));
            return customer;
        }

        public async Task<CustomerResponse> PostCustomer(CustomerRequest customerDetails)
        {
            await _addressService.CheckAddress(customerDetails.AddressId);
            var addedCustomer = await _customerRepository.PostCustomer(customerDetails);
            return Customer.CustomerToResponseDTO(addedCustomer);
        }
    }
}
