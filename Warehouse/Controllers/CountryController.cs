using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("countries")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            List<CountryResponse> countries;
            try
            {
                countries = await _countryService.GetCountries();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(countries);
        }

        [HttpGet("{countryid}")]
        public async Task<IActionResult> GetCountry(int countryid)
        {
            CountryResponse country;
            try
            {
                country = await _countryService.GetCountry(countryid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> PostCountry(CountryRequest countryDetails)
        {
            CountryResponse addedCountry;
            try
            {
                addedCountry = await _countryService.PostCountry(countryDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostCountry), addedCountry);
        }
    }
}
