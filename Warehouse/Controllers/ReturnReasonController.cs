using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("return-reasons")]
    public class ReturnReasonController : ControllerBase
    {
        private readonly IReturnReasonService _returnReasonService;

        public ReturnReasonController(IReturnReasonService returnReasonService)
        {
            _returnReasonService = returnReasonService;
        }

        [HttpGet]
        public async Task<IActionResult> GetReturnReasons()
        {
            List<ReturnReasonResponse> returnReasons;
            try
            {
                returnReasons = await _returnReasonService.GetReturnReasons();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(returnReasons);
        }

        [HttpGet("{returnreasonid}")]
        public async Task<IActionResult> GetReturnReason(int returnreasonid)
        {
            ReturnReasonResponse returnReason;
            try
            {
                returnReason = await _returnReasonService.GetReturnReason(returnreasonid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(returnReason);
        }

        [HttpPost]
        public async Task<IActionResult> PostReturnReason(ReturnReasonRequest returnReasonDetails)
        {
            ReturnReasonResponse addedReturnReason;
            try
            {
                addedReturnReason = await _returnReasonService.PostReturnReason(returnReasonDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostReturnReason), addedReturnReason);
        }
    }
}
