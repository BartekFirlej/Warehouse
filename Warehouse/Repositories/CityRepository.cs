using Microsoft.EntityFrameworkCore;
using Warehouse.DTOs;
using Warehouse.Models;

namespace Warehouse.Repositories
{
    public interface ICityRepository
    {
        public Task<List<CityResponse>> GetCities();
        public Task<CityResponse> GetCity(int cityId);
        public Task<City> CheckCity(int cityId);
        public Task<City> PostCity(CityRequest cityDetails);
    }

    public class CityRepository : ICityRepository
    {
        private readonly WarehouseDbContext _context;

        public CityRepository(WarehouseDbContext context)
        {
            _context = context;
        }

        public async Task<List<CityResponse>> GetCities()
        {
            return await _context.Cities
               .AsNoTracking()
               .Select(c => City.CityToResponseDTO(c))
               .ToListAsync();
        }

        public async Task<CityResponse> GetCity(int cityId)
        {
            return await _context.Cities
                .AsNoTracking()
                .Where(c => c.CityId == cityId)
                .Select(c => City.CityToResponseDTO(c))
                .FirstOrDefaultAsync();
        }

        public async Task<City> CheckCity(int cityId)
        {
            return await _context.Cities
                .AsNoTracking()
                .Where(c => c.CityId == cityId)
                .FirstOrDefaultAsync();
        }

        public async Task<City> PostCity(CityRequest cityDetails)
        {
            var cityToAdd = new City
            {
                CityName = cityDetails.CityName,
                PostalCode = cityDetails.PostalCode,
                VoivodeshipId = cityDetails.VoivodeshipId
            };
            await _context.Cities.AddAsync(cityToAdd);
            await _context.SaveChangesAsync();
            return cityToAdd;
        }
    }
}
