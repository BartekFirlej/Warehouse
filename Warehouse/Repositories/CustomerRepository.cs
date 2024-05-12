using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerResponse>> GetCustomers();
        public Task<CustomerResponse> GetCustomer(int customerId);
        public Task<Customer> CheckCustomer(int customerId);
        public Task<Customer> PostCustomer(CustomerRequest customerDetails);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly WarehouseDbContext _context;

        public CustomerRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerResponse>> GetCustomers()
        {
            return await _context.Customers
                .AsNoTracking()
                .Select(c => Customer.CustomerToResponseDTO(c))
                .ToListAsync();
        }

        public async Task<CustomerResponse> GetCustomer(int customerId)
        {
            return await _context.Customers
                .AsNoTracking()
                .Where(c => c.CustomerId == customerId)
                .Select(c => Customer.CustomerToResponseDTO(c))
                .FirstOrDefaultAsync();
        }

        public async Task<Customer> CheckCustomer(int customerId)
        {
            return await _context.Customers
                .AsNoTracking()
                .Where(c => c.CustomerId == customerId)
                .FirstOrDefaultAsync();
        }

        public async Task<Customer> PostCustomer(CustomerRequest customerDetails)
        {
            var customerToAdd = Customer.RequestDTOToCustomer(customerDetails);
            await _context.Customers.AddAsync(customerToAdd);
            await _context.SaveChangesAsync();
            return customerToAdd;
        }
    }
}
