using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("cities")]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCities()
        {
            List<CityResponse> cities;
            try
            {
                cities = await _cityService.GetCities();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(cities);
        }

        [HttpGet("{cityid}")]
        public async Task<IActionResult> GetCity(int cityid)
        {
            CityResponse city;
            try
            {
                city = await _cityService.GetCity(cityid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> PostCity(CityRequest cityDetails)
        {
            CityResponse addedCity;
            try
            {
                addedCity = await _cityService.PostCity(cityDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostCity), addedCity);
        }
    }
}
