using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface ICountryRepository
    {
        public Task<List<CountryResponse>> GetCountries();
        public Task<CountryResponse> GetCountry(int countryId);
        public Task<Country> CheckCountry(int countryId);
        public Task<Country> PostCountry(CountryRequest countryDetails);
    }

    public class CountryRepository : ICountryRepository
    {
        private readonly WarehouseDbContext _context;

        public CountryRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<CountryResponse>> GetCountries()
        {
            return await _context.Countries
               .AsNoTracking()
               .Select(c => Country.CountryToResponseDTO(c))
               .ToListAsync();
        }

        public async Task<CountryResponse> GetCountry(int countryId)
        {
            return await _context.Countries
                .AsNoTracking()
                .Where(c => c.CountryId == countryId)
                .Select(c => Country.CountryToResponseDTO(c))
                .FirstOrDefaultAsync();
        }

        public async Task<Country> CheckCountry(int countryId)
        {
            return await _context.Countries
                .AsNoTracking()
                .Where(c => c.CountryId == countryId)
                .FirstOrDefaultAsync();
        }

        public async Task<Country> PostCountry(CountryRequest countryDetails)
        {
            var countryToAdd = new Country
            {
                CountryName = countryDetails.CountryName
            };
            await _context.Countries.AddAsync(countryToAdd);
            await _context.SaveChangesAsync();
            return countryToAdd;
        }
    }
}
