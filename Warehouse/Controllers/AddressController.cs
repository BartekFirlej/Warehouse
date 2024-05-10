using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("addresses")]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            List<AddressResponse> addresses;
            try
            {
                addresses = await _addressService.GetAddresses();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(addresses);
        }

        [HttpGet("{addressid}")]
        public async Task<IActionResult> GetAddress(int addressid)
        {
            AddressResponse address;
            try
            {
                address = await _addressService.GetAddress(addressid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(address);
        }

        [HttpPost]
        public async Task<IActionResult> PostAddress(AddressRequest addressDetails)
        {
            AddressResponse addedAddress;
            try
            {
                addedAddress = await _addressService.PostAddress(addressDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostAddress), addedAddress);
        }
    }
}
