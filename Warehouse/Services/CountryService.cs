using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface ICountryService
    {
        public Task<List<CountryResponse>> GetCountries();
        public Task<CountryResponse> GetCountry(int countryId);
        public Task<Country> CheckCountry(int countryId);
        public Task<CountryResponse> PostCountry(CountryRequest countryDetails);
    }

    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;

        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<List<CountryResponse>> GetCountries()
        {
            var countries = await _countryRepository.GetCountries();
            if (!countries.Any())
                throw new Exception("Not found any countries.");
            return countries;
        }

        public async Task<CountryResponse> GetCountry(int countryId)
        {
            var country = await _countryRepository.GetCountry(countryId);
            if (country == null)
                throw new Exception(String.Format("Not found any country with id {0}.", countryId));
            return country;
        }

        public async Task<Country> CheckCountry(int countryId)
        {
            var country = await _countryRepository.CheckCountry(countryId);
            if (country == null)
                throw new Exception(String.Format("Not found any country with id {0}.", countryId));
            return country;
        }

        public async Task<CountryResponse> PostCountry(CountryRequest countryDetails)
        {
            return await _countryRepository.PostCountry(countryDetails);
        }

    }
}
