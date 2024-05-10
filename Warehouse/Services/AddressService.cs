using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface IAddressService
    {
        public Task<List<AddressResponse>> GetAddresses();
        public Task<AddressResponse> GetAddress(int addressId);
        public Task<Address> CheckAddress(int addressId);
        public Task<AddressResponse> PostAddress(AddressRequest addressDetails);
    }

    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ICityService _cityService;

        public AddressService(IAddressRepository addressRepository, ICityService cityService)
        {
            _addressRepository = addressRepository;
            _cityService = cityService;
        }

        public async Task<List<AddressResponse>> GetAddresses()
        {
            var addresses = await _addressRepository.GetAddresses();
            if (!addresses.Any())
                throw new Exception("Not found any addresses.");
            return addresses;
        }

        public async Task<AddressResponse> GetAddress(int addressId)
        {
            var address = await _addressRepository.GetAddress(addressId);
            if (address == null)
                throw new Exception(String.Format("Not found any address with id {0}.", addressId));
            return address;
        }

        public async Task<Address> CheckAddress(int addressId)
        {
            var address = await _addressRepository.CheckAddress(addressId);
            if (address == null)
                throw new Exception(String.Format("Not found any address with id {0}.", addressId));
            return address;
        }

        public async Task<AddressResponse> PostAddress(AddressRequest addressDetails)
        {
            await _cityService.CheckCity(addressDetails.CityId);
            var addedAddress = await _addressRepository.PostAddress(addressDetails);
            return Address.AddressToResponseDTO(addedAddress);
        }
    }
}
