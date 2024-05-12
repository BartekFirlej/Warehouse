using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface IAddressRepository
    {
        public Task<List<AddressResponse>> GetAddresses();
        public Task<AddressResponse> GetAddress(int addressId);
        public Task<Address> CheckAddress(int addressId);
        public Task<AddressResponse> PostAddress(AddressRequest addressDetails);
    }

    public class AddressRepository : IAddressRepository
    {
        private readonly WarehouseDbContext _context;

        public AddressRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<AddressResponse>> GetAddresses()
        {
            return await _context.Addresses
               .AsNoTracking()
               .Select(a => Address.AddressToResponseDTO(a))
               .ToListAsync();
        }

        public async Task<AddressResponse> GetAddress(int addressId)
        {
            return await _context.Addresses
                .AsNoTracking()
                .Where(a => a.AddressId == addressId)
                .Select(a => Address.AddressToResponseDTO(a))
                .FirstOrDefaultAsync();
        }

        public async Task<Address> CheckAddress(int addressId)
        {
            return await _context.Addresses
                .AsNoTracking()
                .Where(a => a.AddressId == addressId)
                .FirstOrDefaultAsync();
        }

        public async Task<AddressResponse> PostAddress(AddressRequest addressDetails)
        {
            var addressToAdd = Address.RequestDTOToAddress(addressDetails);
            var addedAddress = await _context.Addresses.AddAsync(addressToAdd);
            await _context.SaveChangesAsync();
            return Address.AddressToResponseDTO(addedAddress.Entity);
        }
    }
}
