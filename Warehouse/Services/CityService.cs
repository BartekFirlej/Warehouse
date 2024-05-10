using Warehouse.DTOs;
using Warehouse.Models;
using Warehouse.Repositories;

namespace Warehouse.Services
{
    public interface ICityService
    {
        public Task<List<CityResponse>> GetCities();
        public Task<CityResponse> GetCity(int cityId);
        public Task<City> CheckCity(int cityId);
        public Task<CityResponse> PostCity(CityRequest cityDetails);
    }

    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly IVoivodeshipService _voivodeshipService;

        public CityService(ICityRepository cityRepository, IVoivodeshipService voivodeshipService)
        {
            _cityRepository = cityRepository;
            _voivodeshipService = voivodeshipService;
        }

        public async Task<List<CityResponse>> GetCities()
        {
            var cities = await _cityRepository.GetCities();
            if (!cities.Any())
                throw new Exception("Not found any cities.");
            return cities;
        }

        public async Task<CityResponse> GetCity(int cityId)
        {
            var city = await _cityRepository.GetCity(cityId);
            if (city == null)
                throw new Exception(String.Format("Not found any city with id {0}.", cityId));
            return city;
        }

        public async Task<City> CheckCity(int cityId)
        {
            var city = await _cityRepository.CheckCity(cityId);
            if (city == null)
                throw new Exception(String.Format("Not found any city with id {0}.", cityId));
            return city;
        }

        public async Task<CityResponse> PostCity(CityRequest cityDetails)
        {
            await _voivodeshipService.CheckVoivodeship(cityDetails.VoivodeshipId);
            var addedCity = await _cityRepository.PostCity(cityDetails);
            return City.CityToResponseDTO(addedCity);
        }
    }
}
