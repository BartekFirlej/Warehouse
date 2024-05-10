using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("voivodeships")]
    public class VoivodeshipController : ControllerBase
    {
        private readonly IVoivodeshipService _voivodeshipService;

        public VoivodeshipController(IVoivodeshipService voivodeshipService)
        {
            _voivodeshipService = voivodeshipService;
        }

        [HttpGet]
        public async Task<IActionResult> GetVoivodeships()
        {
            List<VoivodeshipResponse> voivodeships;
            try
            {
                voivodeships = await _voivodeshipService.GetVoivodeships();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(voivodeships);
        }

        [HttpGet("{voivodeshipid}")]
        public async Task<IActionResult> GetVoivodeship(int voivodeshipid)
        {
            VoivodeshipResponse voivodeship;
            try
            {
                voivodeship = await _voivodeshipService.GetVoivodeship(voivodeshipid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(voivodeship);
        }

        [HttpPost]
        public async Task<IActionResult> PostVoivodeship(VoivodeshipRequest voivodeshipDetails)
        {
            VoivodeshipResponse addedVoivodeship;
            try
            {
                addedVoivodeship = await _voivodeshipService.PostVoivodeship(voivodeshipDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostVoivodeship), addedVoivodeship);
        }
    }
}
